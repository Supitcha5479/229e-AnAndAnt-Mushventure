using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable // interface ��Ǿ������� ����׺�ʹ�÷�駹�� ��е�ͧ�� public
{
    GameObject Bullet { get; set; } //[SerializeField] ��Ѻ private ��ҹ��
    Transform BulletSpawnPoint { get; set; } //������ interface �� public ������������ͧ������ ����õ�ͧ����͹�ѹ public ���˹�Ҿ�����˭�

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    void Shoot();

}
