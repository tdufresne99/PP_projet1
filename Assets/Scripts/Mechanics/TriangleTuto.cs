using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleTuto : MonoBehaviour
{
    public GameObject acuteGO;
    public GameObject obtuseGO;
    public GameObject rightGO;
    public GameObject isoscelesGO;
    public GameObject equilateralGO;
    public GameObject scaleneGO;

    [SerializeField] private float _horizontalSpeed = 0.02f;

    private float _direction;
    void Start()
    {
        CurrentStateEnum = ShapeStateEnum.Acute;
        acuteGO.SetActive(true);
    }
    private void Update()
    {
        _direction = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(Vector3.forward * 90f, Space.World);
            SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.PlayerRotateSFX);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            switch (CurrentStateEnum)
            {
                case ShapeStateEnum.Acute:
                    CurrentStateEnum = ShapeStateEnum.Obtuse;
                    SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.PlayerShapeShiftSFX);

                    acuteGO.SetActive(false);
                    obtuseGO.SetActive(true);
                    break;

                case ShapeStateEnum.Obtuse:
                    CurrentStateEnum = ShapeStateEnum.Right;
                    SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.PlayerShapeShiftSFX);

                    obtuseGO.SetActive(false);
                    rightGO.SetActive(true);
                    break;

                case ShapeStateEnum.Right:
                    CurrentStateEnum = ShapeStateEnum.Equilateral;
                    SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.PlayerShapeShiftSFX);

                    rightGO.SetActive(false);
                    equilateralGO.SetActive(true);
                    break;

                case ShapeStateEnum.Equilateral:
                    CurrentStateEnum = ShapeStateEnum.Isosceles;
                    SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.PlayerShapeShiftSFX);

                    equilateralGO.SetActive(false);
                    isoscelesGO.SetActive(true);
                    break;

                case ShapeStateEnum.Isosceles:
                    CurrentStateEnum = ShapeStateEnum.Scalene;
                    SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.PlayerShapeShiftSFX);

                    isoscelesGO.SetActive(false);
                    scaleneGO.SetActive(true);
                    break;

                case ShapeStateEnum.Scalene:
                    CurrentStateEnum = ShapeStateEnum.Acute;
                    SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.PlayerShapeShiftSFX);

                    scaleneGO.SetActive(false);
                    acuteGO.SetActive(true);
                    break;

                default:
                    break;
            }
        }
    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * _direction * _horizontalSpeed, Space.World);
        if (transform.position.x > Model.Instance.RightLimit) transform.position = new Vector3(Model.Instance.RightLimit, transform.position.y, transform.position.z);
        else if (transform.position.x < Model.Instance.LeftLimit) transform.position = new Vector3(Model.Instance.LeftLimit, transform.position.y, transform.position.z);
    }
    public ShapeStateEnum CurrentStateEnum;
}
