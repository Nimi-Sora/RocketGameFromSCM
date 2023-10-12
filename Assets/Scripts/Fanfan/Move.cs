using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]

public class Move : MonoBehaviour
{
    Animator animator;
    Transform cameraTransform;
    Transform playerTransform;
    CharacterController characterController;

    /// <summary>
    /// 玩家姿态 站、下坡(矮楼梯)
    /// </summary>
    public enum PlayerPosture
    {
        Stand,
        Fall
    }
    public PlayerPosture playerPosture = PlayerPosture.Stand;

    /// <summary>
    /// 移动状态 闲置、走路、跑步
    /// </summary>
    public enum LocomotionState
    {
        Idle,
        Walk,
        Run,
    }
    public LocomotionState locomotionState = LocomotionState.Idle;

    //接收移动输入
    Vector2 moveInput;

    //接收是否执行蹲、跑、跳、下坡操作
    bool isRun = false;
    bool isFall = false;
    float downHeight = 0f;


    //玩家移动距离
    Vector3 playerMoveDistance = Vector3.zero;
    //玩家实际移动距离
    Vector3 currentMoveDistance = Vector3.zero;

    //玩家走、跑、旋转、滑行的速度
    public float walkSpeed = 2.5f;
    public float runSpeed = 5f;
    public float rotateSpeed = 600f;
    //旋转时间
    public float rotateTime = 0.1f;
    //重力
    public float gravity = -22f;
    //下落重力倍率
    public float fallGravityMultiple = 1.5f;
    //垂直速度
    Vector3 verticalSpeed = Vector3.zero;
    //旋转角度
    float targetAngle;

    //计算起跳前三帧平均速度
    static int threeFrame = 3;
    Vector3[] cacheVal = new Vector3[threeFrame];
    int firstCacheVal = 0;
    Vector3 averageVal = Vector3.zero;

    //检测角色是否落地
    bool isGrounded = false;
    float groundCheck = 1.2f;

    //动画机控制参数
    int moveSwitchHash;
    int isRunHash;
    float standParameter = 0f;
    float walkParameter = 1f;

    //开始动画无法移动
    float beginCD = 3.4f;
    bool isBegin = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
        playerTransform = GetComponent<Transform>();
        characterController = GetComponent<CharacterController>();

        downHeight = characterController.stepOffset;
        moveSwitchHash = Animator.StringToHash("MoveSwitch");
        isRunHash = Animator.StringToHash("IsRun");
        StartCoroutine(IsBegin());

    }

    void Update()
    {
        GroundCheck();
        PlayerVerticalVelocity();
        PlayerMoveDirection();
        SwitchPlayerState();
        PlayerPostureAndSpeed();
        PlayerMove();

    }

    /// <summary>
    /// 协程 判断开场动画是否结束
    /// </summary>
    /// <returns></returns>
    IEnumerator IsBegin()
    {
        yield return new WaitForSeconds(beginCD);
        isBegin = false;
    }

    #region 接收键盘输入的指令
    public void GetMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void GetRunInput(InputAction.CallbackContext context)
    {
        isRun = context.ReadValueAsButton();
    }
    #endregion

    /// <summary>
    /// 检测玩家是否落地
    /// </summary>
    void GroundCheck()
    {
        //射线检测 检测玩家是否在地面
        if (Physics.SphereCast(playerTransform.position + (Vector3.up * groundCheck), characterController.radius * 20, Vector3.down,
            out RaycastHit hitInfo, groundCheck - characterController.radius * 20 + characterController.skinWidth * 2))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            isFall = !Physics.Raycast(playerTransform.position, Vector3.down, downHeight);
        }
;
    }

    /// <summary>
    /// 计算玩家垂直方向速度
    /// </summary>
    void PlayerVerticalVelocity()
    {
        if (playerPosture != PlayerPosture.Fall)
        {
            if (!isGrounded)
            {
                //下楼时的重力
                verticalSpeed.y += gravity * Time.deltaTime;
            }
            else
            {
                verticalSpeed.y = -2f * Time.deltaTime;
            }
        }
        else
        {
                verticalSpeed.y += gravity * Time.deltaTime;
        }
    }

    /// <summary>
    /// 玩家移动方向计算
    /// </summary>
    void PlayerMoveDirection()
    {
        if (!isBegin)
        {
            //有移动输入时才旋转
            if (moveInput.magnitude != 0)
            {
                targetAngle = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
                //四元数乘前向量转换为Vector3
                playerMoveDistance = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized;

                Quaternion targetRotation = Quaternion.LookRotation(playerMoveDistance, Vector3.up);
                playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            }
            else
            {
                playerMoveDistance.x = 0f;
                playerMoveDistance.z = 0f;
            }
        }
    }

    /// <summary>
    /// 选择玩家姿势、运动状态
    /// </summary>
    void SwitchPlayerState()
    {
        //判断玩家姿势
        if (!isGrounded)
        {
            if (isFall)
            {
                playerPosture = PlayerPosture.Fall;
            }

        }
        else
        {
            playerPosture = PlayerPosture.Stand;
        }

        //判断玩家运动状态
        if (moveInput.magnitude == 0)
        {
            locomotionState = LocomotionState.Idle;
        }
        else if (moveInput.magnitude != 0 && isRun == false)
        {
            locomotionState = LocomotionState.Walk;
        }
        else if (moveInput.magnitude != 0 && isRun == true)
        {
            locomotionState = LocomotionState.Run;
        }
    }

    /// <summary>
    /// 设置玩家姿态和速度
    /// </summary>
    void PlayerPostureAndSpeed()
    {
        //如果玩家状态是站立 判断并修改玩家姿态和移动速度
        if (playerPosture == PlayerPosture.Stand && isGrounded)
        {
            //+播放站立姿态动画
            switch (locomotionState)
            {
                case LocomotionState.Idle:
                    currentMoveDistance = Vector3.zero;
                    //+播放站立动画
                    animator.SetFloat(moveSwitchHash, standParameter, 0.1f, Time.deltaTime);
                    animator.SetBool(isRunHash, false);
                    break;
                case LocomotionState.Walk:
                    currentMoveDistance = playerMoveDistance * walkSpeed;
                    //+播放走路动画
                    animator.SetFloat(moveSwitchHash, walkParameter, 0.1f, Time.deltaTime);
                    animator.SetBool(isRunHash, false);
                    break;
                case LocomotionState.Run:
                    currentMoveDistance = playerMoveDistance * runSpeed;
                    //+播放跑步动画
                    animator.SetBool(isRunHash, true);
                    break;
            }
        }
        else if (playerPosture == PlayerPosture.Fall)
        {
            currentMoveDistance = playerMoveDistance * 5;
            animator.SetFloat(moveSwitchHash, standParameter, 0.1f, Time.deltaTime);
            //averageVal.y = verticalSpeed.y;
        }
    }

    /// <summary>
    /// 计算前三帧平均速度(大部分时间持续
    /// </summary>
    /// <param name="newVal"></param>
    /// <returns></returns>
    Vector3 AverageVal(Vector3 newVal)
    {
        cacheVal[firstCacheVal] = newVal;
        firstCacheVal++;
        firstCacheVal %= threeFrame;
        Vector3 average = Vector3.zero;
        foreach (Vector3 val in cacheVal)
        {
            average += val;
        }
        return average / threeFrame;
    }

    /// <summary>
    /// 玩家移动
    /// </summary>
    void PlayerMove()
    {
        //玩家在地面移动
        //if (playerPosture != PlayerPosture.Fall)
        //{
            characterController.Move(verticalSpeed * Time.deltaTime);
            characterController.Move(currentMoveDistance * Time.deltaTime);
            //averageVal = AverageVal(characterController.velocity);
        //}
        ////玩家在空中时移动
        //else if (playerPosture == PlayerPosture.Fall)
        //{
        //    characterController.Move(verticalSpeed * Time.deltaTime);
        //    characterController.Move(averageVal * Time.deltaTime);
        //    characterController.Move(currentMoveDistance * Time.deltaTime);
        //}
        //print("姿态" + playerPosture);
        //print("动作" + locomotionState);
        //print("滑行" + isSlip);
        //print("最后3" + averageVal);
        //print("角色速度"+characterController.velocity);
        //print(playerTransform.position);
        //print("长度"+averageVal.magnitude);
        //print("地面" + isGrounded);
        //print((animatorStateInfo.normalizedTime > 0.99f) && animatorStateInfo.IsName("anim_open"));
        //print("时间" + (animatorStateInfo.normalizedTime > 0.99f));
        //print("名称" + animatorStateInfo.IsTag("1"));
    }


}
