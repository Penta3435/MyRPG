using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Properties")]
    [SerializeField] float speed = 20f;
    [SerializeField] GameObject mainCharacterPrefab;

    [Header("References")]
    [SerializeField] CharacterController cc;
    [SerializeField] PlayerInput pInput;

    [SerializeField] MainCharacterContainer mainCharacterContainer;
    [SerializeField] CharacterContainer companionContainer;

    //UI
    [SerializeField] Transform canvasForCharacters;



    public bool canMove;
    //internal properties
    private Vector3 movementDirection;
    private Vector3 mouseWorldPosition;

    private InputActionAsset iActionAsset;

    private CharacterContainer currentCharacterContainerBehaviour;


    private void OnEnable()
    {
        iActionAsset = pInput.actions;
        iActionAsset.FindActionMap("PlayerRunning").FindAction("SwitchCharacters").started += ChangeCharacters;
        iActionAsset.FindActionMap("PlayerRunning").FindAction("SwitchWeapons").started += SwitchWeapon;
        iActionAsset.FindActionMap("PlayerRunning").FindAction("EquipMelee").started += SwitchToMelee;
        iActionAsset.FindActionMap("PlayerRunning").FindAction("Atack").started += Atack;
        //iActionAsset.FindActionMap("PlayerRunning").FindAction("Ability1").started += Ability1;
        //iActionAsset.FindActionMap("PlayerRunning").FindAction("Ability2").started += Ability2;

    }
    private void Start()
    {
        SetupMainCharacter();
        currentCharacterContainerBehaviour = mainCharacterContainer;
        mainCharacterContainer.gameObject.SetActive(true);
        companionContainer.gameObject.SetActive(false);
    }

    #region Update_Behaviours
    void Update()
    {
        if (canMove) PlayerMovement();
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
        movementDirection = new Vector3(v2MovementDirection.x, 0, v2MovementDirection.y);

        cc.SimpleMove(movementDirection * speed);
    }
    private void PlayerRotation()
    {
        Vector2 mousePosition = iActionAsset.FindActionMap("PlayerRunning").FindAction("MousePosition").ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        mainCharacterContainer.character = currentCharacterContainerBehaviour.character;
        Plane weaponHightPlane = new Plane(Vector3.up, new Vector3(0, currentCharacterContainerBehaviour.character.Hand.position.y, 0));
        if (weaponHightPlane.Raycast(ray, out float rayDistance))
        {
            mouseWorldPosition = new Vector3(ray.GetPoint(rayDistance).x, transform.position.y, ray.GetPoint(rayDistance).z);
            transform.LookAt(mouseWorldPosition);
        }

    }
    void ChangeCharacters(InputAction.CallbackContext ctx)
    {
        if(ctx.started && companionContainer.transform.childCount == 1)
        {
            if (mainCharacterContainer.gameObject.activeSelf == true)
            {
                mainCharacterContainer.gameObject.SetActive(false);
                companionContainer.gameObject.SetActive(true);

                currentCharacterContainerBehaviour = companionContainer;
            }
            else
            {
                mainCharacterContainer.gameObject.SetActive(true);
                companionContainer.gameObject.SetActive(false);

                currentCharacterContainerBehaviour = mainCharacterContainer;
            }
        }
    }
    #endregion


    #region Character_Behaviour
    void SetupMainCharacter()
    {
        mainCharacterContainer.EquipCharacter(mainCharacterPrefab, canvasForCharacters);
    }

    //public for test
    public void EquipCharacter(GameObject character)
    {
        companionContainer.EquipCharacter(character, canvasForCharacters);
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
    public void Ability1(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) currentCharacterContainerBehaviour.Ability1(movementDirection, mouseWorldPosition, this);
    }
    public void Ability2(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) currentCharacterContainerBehaviour.Ability2(movementDirection, mouseWorldPosition, this);
    }
        //public for test
    public void EquipAbility1(GameObject ability)
    {
        mainCharacterContainer.EquipAbility1(ability);
    }
    public void EquipAbility2(GameObject ability)
    {
        mainCharacterContainer.EquipAbility2(ability);
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
