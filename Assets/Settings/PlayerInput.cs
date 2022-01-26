// GENERATED AUTOMATICALLY FROM 'Assets/Settings/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""StandardControls"",
            ""id"": ""d61d3372-a49f-42b7-afa6-bdd97a0b154d"",
            ""actions"": [
                {
                    ""name"": ""SelectLeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""e79aa25c-2438-46bd-a88b-b3c518a814ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectWaypoint"",
                    ""type"": ""Button"",
                    ""id"": ""177c4d57-3d92-406c-bab6-912a94f08652"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold,Tap""
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""73f1d0d7-d9a4-4960-a09a-2d2c293a2ae0"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateCameraHorizontal"",
                    ""type"": ""Button"",
                    ""id"": ""1cef6b1d-4a8a-4cb5-80d6-bc1548cfed2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateCameraVertical"",
                    ""type"": ""Button"",
                    ""id"": ""bd72a917-8271-400f-976c-7c94e12aabc9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""dd88910d-9546-458a-b4b2-698a448df993"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aaacd5e4-36b0-41c1-8e03-bfa539929a12"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectLeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b74859af-006b-456a-ac31-e9328645f657"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectWaypoint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1b19104-4302-4fec-af4d-95017126cbfa"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7c170fef-ee73-4828-b76f-554c3323387a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCameraHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b7eb8a10-e54f-4a4b-b288-7a9a8a9dbe88"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""26350182-8cf9-4c45-af1d-f449d19aa83c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c7a0f0d0-0002-47a8-a4a3-a5f7c4c98bd7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f38e8190-deeb-47cc-a6a5-f85cdbf1898a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b90c1f74-f6ec-4b0c-8aa1-7e48dc92db05"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCameraVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74780f66-e07a-4e87-afad-f9cb29e3f58d"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // StandardControls
        m_StandardControls = asset.FindActionMap("StandardControls", throwIfNotFound: true);
        m_StandardControls_SelectLeftClick = m_StandardControls.FindAction("SelectLeftClick", throwIfNotFound: true);
        m_StandardControls_SelectWaypoint = m_StandardControls.FindAction("SelectWaypoint", throwIfNotFound: true);
        m_StandardControls_Zoom = m_StandardControls.FindAction("Zoom", throwIfNotFound: true);
        m_StandardControls_RotateCameraHorizontal = m_StandardControls.FindAction("RotateCameraHorizontal", throwIfNotFound: true);
        m_StandardControls_RotateCameraVertical = m_StandardControls.FindAction("RotateCameraVertical", throwIfNotFound: true);
        m_StandardControls_Pause = m_StandardControls.FindAction("Pause", throwIfNotFound: true);
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

    // StandardControls
    private readonly InputActionMap m_StandardControls;
    private IStandardControlsActions m_StandardControlsActionsCallbackInterface;
    private readonly InputAction m_StandardControls_SelectLeftClick;
    private readonly InputAction m_StandardControls_SelectWaypoint;
    private readonly InputAction m_StandardControls_Zoom;
    private readonly InputAction m_StandardControls_RotateCameraHorizontal;
    private readonly InputAction m_StandardControls_RotateCameraVertical;
    private readonly InputAction m_StandardControls_Pause;
    public struct StandardControlsActions
    {
        private @PlayerInput m_Wrapper;
        public StandardControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectLeftClick => m_Wrapper.m_StandardControls_SelectLeftClick;
        public InputAction @SelectWaypoint => m_Wrapper.m_StandardControls_SelectWaypoint;
        public InputAction @Zoom => m_Wrapper.m_StandardControls_Zoom;
        public InputAction @RotateCameraHorizontal => m_Wrapper.m_StandardControls_RotateCameraHorizontal;
        public InputAction @RotateCameraVertical => m_Wrapper.m_StandardControls_RotateCameraVertical;
        public InputAction @Pause => m_Wrapper.m_StandardControls_Pause;
        public InputActionMap Get() { return m_Wrapper.m_StandardControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StandardControlsActions set) { return set.Get(); }
        public void SetCallbacks(IStandardControlsActions instance)
        {
            if (m_Wrapper.m_StandardControlsActionsCallbackInterface != null)
            {
                @SelectLeftClick.started -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnSelectLeftClick;
                @SelectLeftClick.performed -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnSelectLeftClick;
                @SelectLeftClick.canceled -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnSelectLeftClick;
                @SelectWaypoint.started -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnSelectWaypoint;
                @SelectWaypoint.performed -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnSelectWaypoint;
                @SelectWaypoint.canceled -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnSelectWaypoint;
                @Zoom.started -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnZoom;
                @RotateCameraHorizontal.started -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnRotateCameraHorizontal;
                @RotateCameraHorizontal.performed -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnRotateCameraHorizontal;
                @RotateCameraHorizontal.canceled -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnRotateCameraHorizontal;
                @RotateCameraVertical.started -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnRotateCameraVertical;
                @RotateCameraVertical.performed -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnRotateCameraVertical;
                @RotateCameraVertical.canceled -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnRotateCameraVertical;
                @Pause.started -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_StandardControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectLeftClick.started += instance.OnSelectLeftClick;
                @SelectLeftClick.performed += instance.OnSelectLeftClick;
                @SelectLeftClick.canceled += instance.OnSelectLeftClick;
                @SelectWaypoint.started += instance.OnSelectWaypoint;
                @SelectWaypoint.performed += instance.OnSelectWaypoint;
                @SelectWaypoint.canceled += instance.OnSelectWaypoint;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @RotateCameraHorizontal.started += instance.OnRotateCameraHorizontal;
                @RotateCameraHorizontal.performed += instance.OnRotateCameraHorizontal;
                @RotateCameraHorizontal.canceled += instance.OnRotateCameraHorizontal;
                @RotateCameraVertical.started += instance.OnRotateCameraVertical;
                @RotateCameraVertical.performed += instance.OnRotateCameraVertical;
                @RotateCameraVertical.canceled += instance.OnRotateCameraVertical;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public StandardControlsActions @StandardControls => new StandardControlsActions(this);
    public interface IStandardControlsActions
    {
        void OnSelectLeftClick(InputAction.CallbackContext context);
        void OnSelectWaypoint(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnRotateCameraHorizontal(InputAction.CallbackContext context);
        void OnRotateCameraVertical(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
