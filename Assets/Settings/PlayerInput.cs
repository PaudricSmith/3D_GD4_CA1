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
                    ""name"": ""SelectPlayer"",
                    ""type"": ""Button"",
                    ""id"": ""e79aa25c-2438-46bd-a88b-b3c518a814ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,SlowTap""
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
                    ""action"": ""SelectPlayer"",
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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // StandardControls
        m_StandardControls = asset.FindActionMap("StandardControls", throwIfNotFound: true);
        m_StandardControls_SelectPlayer = m_StandardControls.FindAction("SelectPlayer", throwIfNotFound: true);
        m_StandardControls_SelectWaypoint = m_StandardControls.FindAction("SelectWaypoint", throwIfNotFound: true);
        m_StandardControls_Zoom = m_StandardControls.FindAction("Zoom", throwIfNotFound: true);
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
    private readonly InputAction m_StandardControls_SelectPlayer;
    private readonly InputAction m_StandardControls_SelectWaypoint;
    private readonly InputAction m_StandardControls_Zoom;
    public struct StandardControlsActions
    {
        private @PlayerInput m_Wrapper;
        public StandardControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectPlayer => m_Wrapper.m_StandardControls_SelectPlayer;
        public InputAction @SelectWaypoint => m_Wrapper.m_StandardControls_SelectWaypoint;
        public InputAction @Zoom => m_Wrapper.m_StandardControls_Zoom;
        public InputActionMap Get() { return m_Wrapper.m_StandardControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StandardControlsActions set) { return set.Get(); }
        public void SetCallbacks(IStandardControlsActions instance)
        {
            if (m_Wrapper.m_StandardControlsActionsCallbackInterface != null)
            {
                @SelectPlayer.started -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnSelectPlayer;
                @SelectPlayer.performed -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnSelectPlayer;
                @SelectPlayer.canceled -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnSelectPlayer;
                @SelectWaypoint.started -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnSelectWaypoint;
                @SelectWaypoint.performed -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnSelectWaypoint;
                @SelectWaypoint.canceled -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnSelectWaypoint;
                @Zoom.started -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_StandardControlsActionsCallbackInterface.OnZoom;
            }
            m_Wrapper.m_StandardControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectPlayer.started += instance.OnSelectPlayer;
                @SelectPlayer.performed += instance.OnSelectPlayer;
                @SelectPlayer.canceled += instance.OnSelectPlayer;
                @SelectWaypoint.started += instance.OnSelectWaypoint;
                @SelectWaypoint.performed += instance.OnSelectWaypoint;
                @SelectWaypoint.canceled += instance.OnSelectWaypoint;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
            }
        }
    }
    public StandardControlsActions @StandardControls => new StandardControlsActions(this);
    public interface IStandardControlsActions
    {
        void OnSelectPlayer(InputAction.CallbackContext context);
        void OnSelectWaypoint(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
    }
}
