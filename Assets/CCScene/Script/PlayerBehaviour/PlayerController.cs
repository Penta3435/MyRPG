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

    [SerializeField] CharacterContainerBehaviour mainCharacterBehaviour;
    [SerializeField] CharacterContainerBehaviour companionBehaviour;

    [SerializeField] Transform mainCharacterContainer;
    [SerializeField] Transform companionContainer;


    //internal properties
    private InputActionAsset iActionAsset;

    private CharacterContainerBehaviour currentCharacterContainerBehaviour;


    private void OnEnable()
    {
        iActionAsset = pInput.actions;
        iActionAsset.FindActionMap("PlayerRunning").FindAction("SwitchCharacters").started += ChangeCharacters;
        iActionAsset.FindActionMap("PlayerRunning").FindAction("SwitchWeapons").started += SwitchWeapon;
        iActionAsset.FindActionMap("PlayerRunning").FindAction("EquipMelee").started += SwitchToMelee;
        iActionAsset.FindActionMap("PlayerRunning").FindAction("Atack").started += Atack;
    }
    private void Start()
    {
        SetupMainCharacter();
        currentCharacterContainerBehaviour = mainCharacterBehaviour;
        mainCharacterContainer.gameObject.SetActive(true);
        companionContainer.gameObject.SetActive(false);
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
        Plane weaponHightPlane = new Plane(Vector3.up, new Vector3(0, currentCharacterContainerBehaviour.characterBehaviour.hand.position.y, 0));
        if (weaponHightPlane.Raycast(ray, out float rayDistance))
        {
            transform.LookAt(new Vector3(ray.GetPoint(rayDistance).x, transform.position.y, ray.GetPoint(rayDistance).z));
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
        currentCharacterContainerBehaviour.EquipWeapon(weapon);
    }
    void UnequipWeapon(WeaponContainer weaponContainer)
    {
        currentCharacterContainerBehaviour.UnEquipWeapons(weaponContainer);
    }
    void SwitchWeapon(InputAction.CallbackContext ctx)
    {
        if(ctx.started) 
        {
            currentCharacterContainerBehaviour.SwitchWeapon();
        }
    }
    void SwitchToMelee(InputAction.CallbackContext ctx)
    {
        currentCharacterContainerBehaviour.SwitchToMelee();
    }
    private void Atack(InputAction.CallbackContext ctx)
    {
        if(ctx.started == true)
        {
            currentCharacterContainerBehaviour.Atack();
        }
    }



    //hability
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
        iActionAsset.FindActionMap("PlayerRunning").FindAction("SwitchWeapons").started -= SwitchWeapon;
        iActionAsset.FindActionMap("PlayerRunning").FindAction("EquipMelee").started -= SwitchToMelee;
        iActionAsset.FindActionMap("PlayerRunning").FindAction("Atack").started -= Atack;
    }
}
