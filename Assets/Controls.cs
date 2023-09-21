// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""PlayerSword"",
            ""id"": ""d51d3bb6-a40b-4b3d-bcb8-56a42ec7f043"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4cbbf05d-b64b-41d4-8e60-ba741b1caf19"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttackL"",
                    ""type"": ""Value"",
                    ""id"": ""3340e933-e47b-4cec-b3dc-95e88aaa21e0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttackH"",
                    ""type"": ""Button"",
                    ""id"": ""8301c03a-f2ac-4f93-9c2b-6fa46b5dfe30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7fe69512-cfac-42c9-ac4d-fc12209112f8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""174d7533-f69e-4ad9-acec-23cabfc4fbcb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeWeaponUp"",
                    ""type"": ""Button"",
                    ""id"": ""d7543a0a-6897-499d-9b5a-ed867400b26a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeWeaponDown"",
                    ""type"": ""Button"",
                    ""id"": ""cda8b567-5154-4297-b257-3a83e9c4918b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8fe6a2bc-6c26-4f37-8ca6-7ef4e1d10bc1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""38a9593e-e751-4505-8105-c5607e85a113"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0f08634e-a49c-4340-87dc-69ff1f10a6ec"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f0c96f65-a1f5-4f63-b8f2-b626e33738d3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ec0dfbf8-50f2-414c-b0f4-624768bed70d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cc9736d2-cb58-4499-b7b6-b926e550e7f0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""97aa6163-4b0b-40be-a048-6f26949f244b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de47546a-f245-430d-b9b9-2a657dadfe86"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ce88f4f-af91-4c75-b51c-64afacdc53a8"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c2edd6d-3245-4030-b5ab-b5fec366fa4e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58143feb-1885-4e59-af18-f5c11c283e35"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb206029-5e4d-41f6-9f74-aa9615dd83b6"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b463e8b4-e5d2-43d4-a041-17be211f6a5b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a75e9518-69b5-4151-bd67-376cb3e6d25f"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2132567f-e055-43b8-a563-86ef7528be78"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b8ce6ff-5f6b-489f-88ff-44828f31eb9f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63cf3651-b363-469e-a233-c6fae31021f2"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeWeaponUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42f51ebf-2f6f-4b6f-98d5-7e994d9931a6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeWeaponUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7fdde8b-eb6b-42a4-817f-de57f86f6205"",
                    ""path"": ""<DualShockGamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeWeaponUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9f14b15-8502-45cb-809b-00a4931051cd"",
                    ""path"": ""<DualShockGamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeWeaponDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a79be74a-2a01-44ce-bb2a-c18313f47ce5"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeWeaponDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e9e118c-766f-402d-b118-a620c0a0e389"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeWeaponDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerSword
        m_PlayerSword = asset.FindActionMap("PlayerSword", throwIfNotFound: true);
        m_PlayerSword_Move = m_PlayerSword.FindAction("Move", throwIfNotFound: true);
        m_PlayerSword_AttackL = m_PlayerSword.FindAction("AttackL", throwIfNotFound: true);
        m_PlayerSword_AttackH = m_PlayerSword.FindAction("AttackH", throwIfNotFound: true);
        m_PlayerSword_Look = m_PlayerSword.FindAction("Look", throwIfNotFound: true);
        m_PlayerSword_Roll = m_PlayerSword.FindAction("Roll", throwIfNotFound: true);
        m_PlayerSword_ChangeWeaponUp = m_PlayerSword.FindAction("ChangeWeaponUp", throwIfNotFound: true);
        m_PlayerSword_ChangeWeaponDown = m_PlayerSword.FindAction("ChangeWeaponDown", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerSword
    private readonly InputActionMap m_PlayerSword;
    private IPlayerSwordActions m_PlayerSwordActionsCallbackInterface;
    private readonly InputAction m_PlayerSword_Move;
    private readonly InputAction m_PlayerSword_AttackL;
    private readonly InputAction m_PlayerSword_AttackH;
    private readonly InputAction m_PlayerSword_Look;
    private readonly InputAction m_PlayerSword_Roll;
    private readonly InputAction m_PlayerSword_ChangeWeaponUp;
    private readonly InputAction m_PlayerSword_ChangeWeaponDown;
    public struct PlayerSwordActions
    {
        private @Controls m_Wrapper;
        public PlayerSwordActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerSword_Move;
        public InputAction @AttackL => m_Wrapper.m_PlayerSword_AttackL;
        public InputAction @AttackH => m_Wrapper.m_PlayerSword_AttackH;
        public InputAction @Look => m_Wrapper.m_PlayerSword_Look;
        public InputAction @Roll => m_Wrapper.m_PlayerSword_Roll;
        public InputAction @ChangeWeaponUp => m_Wrapper.m_PlayerSword_ChangeWeaponUp;
        public InputAction @ChangeWeaponDown => m_Wrapper.m_PlayerSword_ChangeWeaponDown;
        public InputActionMap Get() { return m_Wrapper.m_PlayerSword; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerSwordActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerSwordActions instance)
        {
            if (m_Wrapper.m_PlayerSwordActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnMove;
                @AttackL.started -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnAttackL;
                @AttackL.performed -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnAttackL;
                @AttackL.canceled -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnAttackL;
                @AttackH.started -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnAttackH;
                @AttackH.performed -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnAttackH;
                @AttackH.canceled -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnAttackH;
                @Look.started -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnLook;
                @Roll.started -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnRoll;
                @ChangeWeaponUp.started -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnChangeWeaponUp;
                @ChangeWeaponUp.performed -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnChangeWeaponUp;
                @ChangeWeaponUp.canceled -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnChangeWeaponUp;
                @ChangeWeaponDown.started -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnChangeWeaponDown;
                @ChangeWeaponDown.performed -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnChangeWeaponDown;
                @ChangeWeaponDown.canceled -= m_Wrapper.m_PlayerSwordActionsCallbackInterface.OnChangeWeaponDown;
            }
            m_Wrapper.m_PlayerSwordActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @AttackL.started += instance.OnAttackL;
                @AttackL.performed += instance.OnAttackL;
                @AttackL.canceled += instance.OnAttackL;
                @AttackH.started += instance.OnAttackH;
                @AttackH.performed += instance.OnAttackH;
                @AttackH.canceled += instance.OnAttackH;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @ChangeWeaponUp.started += instance.OnChangeWeaponUp;
                @ChangeWeaponUp.performed += instance.OnChangeWeaponUp;
                @ChangeWeaponUp.canceled += instance.OnChangeWeaponUp;
                @ChangeWeaponDown.started += instance.OnChangeWeaponDown;
                @ChangeWeaponDown.performed += instance.OnChangeWeaponDown;
                @ChangeWeaponDown.canceled += instance.OnChangeWeaponDown;
            }
        }
    }
    public PlayerSwordActions @PlayerSword => new PlayerSwordActions(this);
    public interface IPlayerSwordActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttackL(InputAction.CallbackContext context);
        void OnAttackH(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnChangeWeaponUp(InputAction.CallbackContext context);
        void OnChangeWeaponDown(InputAction.CallbackContext context);
    }
}
