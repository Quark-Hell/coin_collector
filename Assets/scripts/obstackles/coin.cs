using DG.Tweening;
using UnityEngine;

public class coin : obstackle
{
    [SerializeField] private float moveDistance = 1f;   // ���������� �������� �����-����
    [SerializeField] private float moveDuration = 1f;   // ����� �� ���� ������/�����
    [SerializeField] private float rotateSpeed = 90f;   // �������� �������� (������� � �������)

    void Start()
    {
        // �������� �������� �����-���� (����-����)
        transform.DOMoveY(transform.position.y + moveDistance, moveDuration)
                 .SetLoops(-1, LoopType.Yoyo)  // ����������� ����
                 .SetEase(Ease.InOutSine);     // ���������

        // �������� �������� ������ ����� ���
        transform.DORotate(new Vector3(0, 360, 0), 360f / rotateSpeed, RotateMode.FastBeyond360)
                 .SetLoops(-1, LoopType.Restart)  // ����������� ����
                 .SetEase(Ease.Linear);          // ����������� ��������
    }

    protected override void move()
    {
        if (IsFree == false)
        {
            transform.position += ObstackleMoving * Time.deltaTime * Speed;
        }
    }
    protected override void TriggerEvent(GameObject other)
    {
        if (other.CompareTag("RespawnCoin"))
        {
            IsFree = true;
        }
    }
    public void release() 
    {
        IsFree = true;
        transform.position = new Vector3(-444.3f, 26.44848f,0);
    }
}