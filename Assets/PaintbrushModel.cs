using UnityEngine;
using DG.Tweening;

namespace SpongeTale
{
    public class PaintbrushModel : MonoBehaviour
    {
        public void ScalePaintbrush()//���� �������� ��������������� ����� � ��������� � �����������
        {
            transform.DOScaleX(0.75f, 1f);
            transform.DOScaleY(0.75f, 1f);
            transform.DOScaleZ(0.75f, 1f);
        }
    }
}
