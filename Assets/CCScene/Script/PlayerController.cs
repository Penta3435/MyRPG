using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Properties")]
    [SerializeField] float speed = 20f;
    [SerializeField] LayerMask layerMaskToRaycastHit;
    [SerializeField] GameObject mainCharacterPrefab;
    [SerializeField] GameObject defaultWeapon;

    [Header("References")]
    [SerializeField] CharacterController cc;

    [SerializeField] PlayerInput pInput;

    [SerializeField] CharacterBehaviour mainCharacterBehaviour;
    [SerializeField] CharacterBehaviour companionBehaviour;

    [SerializeField] Transform mainCharacterContainer;
    [SerializeField] Transform companionContainer;


    //internal properties
    private InputActionAsset iActionAsset;

    private CharacterBehaviour currentCharacterBehaviour;


    private void OnEnable()
    {
        iActionAsset = pInput.actions;
        iActionAsset.FindActionMap("PlayerRunning").FindAction("SwitchCharacters").started += ChangeCharacters;
        iActionAsset.FindActionMap("PlayerRunning").FindAction("Atack").started += PlayerAtack;
    }
    private void Start()
    {
        SetupMainCharacter();
        currentCharacterBehaviour = mainCharacterBehaviour;
        mainCharacterContainer.gameObject.SetActive(true);
        companionContainer.gameObject.SetActive(false);
        EquipWeapon(defaultWeapon);
    }

    #region Update_Behaviours
    void Update()
    {
        PlayerMovement();
    }
    private void LateUpdate()
    {
        PlayerRotation();
    }
    #endregion

    #region Player_Behaviours
    private void PlayerMovement()
    {
        Vector2 v2MovementDirection = iActionAsset.FindActionMap("PlayerRunning").FindAction("Movement").ReadValue<Vector2>();
        Vector3 v3MovementDirection = new Vector3(v2MovementDirection.x, 0, v2MovementDirection.y);

        cc.SimpleMove(v3MovementDirection * speed);
    }
    private void PlayerRotation()
    {
        Vector2 mousePosition = iActionAsset.FindActionMap("PlayerRunning").FindAction("MousePosition").ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layerMaskToRaycastHit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

    }
    void ChangeCharacters(InputAction.CallbackContext ctx)
    {
        if(ctx.started && companionContainer.childCount == 1)
        {
            mainCharacterContainer.gameObject.SetActive(!mainCharacterContainer.gameObject.activeSelf);
            companionContainer.gameObject.SetActive(!companionContainer.gameObject.activeSelf);
        }
    }
    #endregion


    #region Character_Behaviour
    void SetupMainCharacter()
    {
        mainCharacterBehaviour.EquipCharacter(mainCharacterPrefab);
    }

    //public for test
    public void EquipCharacter(GameObject character)
    {
        companionBehaviour.EquipCharacter(character);
    }
    void UnequipCharacter()
    {

    }


    //public for test
    public void EquipWeapon(GameObject weapon)
    {
        currentCharacterBehaviour.EquipWeapon(weapon);
    }
    void UnequipWeapon()
    {

    }




    private void PlayerAtack(InputAction.CallbackContext ctx)
    {
        if(ctx.started == true)
        {
            currentCharacterBehaviour.Atack();
            currentCharacterBehaviour.PlayAtackAnimation();
        }
    }
    void Hability1()
    {

    }
    void Hability2()
    {

    }
    void EquipHability1()
    {

    }
    void EquipHability2()
    {

    }
    #endregion

    

    

    private void OnDisable()
    {
        iActionAsset.FindActionMap("PlayerRunning").FindAction("SwitchCharacters").started -= ChangeCharacters;
        iActionAsset.FindActionMap("PlayerRunning").FindAction("Atack").started -= PlayerAtack;
    }
}
