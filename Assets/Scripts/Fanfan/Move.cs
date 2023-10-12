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
    /// �����̬ վ������(��¥��)
    /// </summary>
    public enum PlayerPosture
    {
        Stand,
        Fall
    }
    public PlayerPosture playerPosture = PlayerPosture.Stand;

    /// <summary>
    /// �ƶ�״̬ ���á���·���ܲ�
    /// </summary>
    public enum LocomotionState
    {
        Idle,
        Walk,
        Run,
    }
    public LocomotionState locomotionState = LocomotionState.Idle;

    //�����ƶ�����
    Vector2 moveInput;

    //�����Ƿ�ִ�жס��ܡ��������²���
    bool isRun = false;
    bool isFall = false;
    float downHeight = 0f;


    //����ƶ�����
    Vector3 playerMoveDistance = Vector3.zero;
    //���ʵ���ƶ�����
    Vector3 currentMoveDistance = Vector3.zero;

    //����ߡ��ܡ���ת�����е��ٶ�
    public float walkSpeed = 2.5f;
    public float runSpeed = 5f;
    public float rotateSpeed = 600f;
    //��תʱ��
    public float rotateTime = 0.1f;
    //����
    public float gravity = -22f;
    //������������
    public float fallGravityMultiple = 1.5f;
    //��ֱ�ٶ�
    Vector3 verticalSpeed = Vector3.zero;
    //��ת�Ƕ�
    float targetAngle;

    //��������ǰ��֡ƽ���ٶ�
    static int threeFrame = 3;
    Vector3[] cacheVal = new Vector3[threeFrame];
    int firstCacheVal = 0;
    Vector3 averageVal = Vector3.zero;

    //����ɫ�Ƿ����
    bool isGrounded = false;
    float groundCheck = 1.2f;

    //���������Ʋ���
    int moveSwitchHash;
    int isRunHash;
    float standParameter = 0f;
    float walkParameter = 1f;

    //��ʼ�����޷��ƶ�
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
    /// Э�� �жϿ��������Ƿ����
    /// </summary>
    /// <returns></returns>
    IEnumerator IsBegin()
    {
        yield return new WaitForSeconds(beginCD);
        isBegin = false;
    }

    #region ���ռ��������ָ��
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
    /// �������Ƿ����
    /// </summary>
    void GroundCheck()
    {
        //���߼�� �������Ƿ��ڵ���
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
    /// ������Ҵ�ֱ�����ٶ�
    /// </summary>
    void PlayerVerticalVelocity()
    {
        if (playerPosture != PlayerPosture.Fall)
        {
            if (!isGrounded)
            {
                //��¥ʱ������
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
    /// ����ƶ��������
    /// </summary>
    void PlayerMoveDirection()
    {
        if (!isBegin)
        {
            //���ƶ�����ʱ����ת
            if (moveInput.magnitude != 0)
            {
                targetAngle = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
                //��Ԫ����ǰ����ת��ΪVector3
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
    /// ѡ��������ơ��˶�״̬
    /// </summary>
    void SwitchPlayerState()
    {
        //�ж��������
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

        //�ж�����˶�״̬
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
    /// ���������̬���ٶ�
    /// </summary>
    void PlayerPostureAndSpeed()
    {
        //������״̬��վ�� �жϲ��޸������̬���ƶ��ٶ�
        if (playerPosture == PlayerPosture.Stand && isGrounded)
        {
            //+����վ����̬����
            switch (locomotionState)
            {
                case LocomotionState.Idle:
                    currentMoveDistance = Vector3.zero;
                    //+����վ������
                    animator.SetFloat(moveSwitchHash, standParameter, 0.1f, Time.deltaTime);
                    animator.SetBool(isRunHash, false);
                    break;
                case LocomotionState.Walk:
                    currentMoveDistance = playerMoveDistance * walkSpeed;
                    //+������·����
                    animator.SetFloat(moveSwitchHash, walkParameter, 0.1f, Time.deltaTime);
                    animator.SetBool(isRunHash, false);
                    break;
                case LocomotionState.Run:
                    currentMoveDistance = playerMoveDistance * runSpeed;
                    //+�����ܲ�����
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
    /// ����ǰ��֡ƽ���ٶ�(�󲿷�ʱ�����
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
    /// ����ƶ�
    /// </summary>
    void PlayerMove()
    {
        //����ڵ����ƶ�
        //if (playerPosture != PlayerPosture.Fall)
        //{
            characterController.Move(verticalSpeed * Time.deltaTime);
            characterController.Move(currentMoveDistance * Time.deltaTime);
            //averageVal = AverageVal(characterController.velocity);
        //}
        ////����ڿ���ʱ�ƶ�
        //else if (playerPosture == PlayerPosture.Fall)
        //{
        //    characterController.Move(verticalSpeed * Time.deltaTime);
        //    characterController.Move(averageVal * Time.deltaTime);
        //    characterController.Move(currentMoveDistance * Time.deltaTime);
        //}
        //print("��̬" + playerPosture);
        //print("����" + locomotionState);
        //print("����" + isSlip);
        //print("���3" + averageVal);
        //print("��ɫ�ٶ�"+characterController.velocity);
        //print(playerTransform.position);
        //print("����"+averageVal.magnitude);
        //print("����" + isGrounded);
        //print((animatorStateInfo.normalizedTime > 0.99f) && animatorStateInfo.IsName("anim_open"));
        //print("ʱ��" + (animatorStateInfo.normalizedTime > 0.99f));
        //print("����" + animatorStateInfo.IsTag("1"));
    }


}
