using UnityEngine;
using TMPro;
using System;
using Mirror;

public class ChatBehaviour : NetworkBehaviour
{
    [SerializeField] GameObject chatUI;
    [SerializeField] TMP_Text chatText;
    [SerializeField] TMP_InputField inputField;

    static event Action<string> OnMessage;

    public override void OnStartAuthority()
    {
        chatUI.SetActive(true);
        OnMessage += HandleNewMessage;
    }

    [ClientCallback]
    private void OnDestroy()
    {
        if (!hasAuthority) return;
        OnMessage -= HandleNewMessage;

    }

    void HandleNewMessage(string message)
    {
        chatText.text += message;
    }

    [Client]
    public void Send(string message)
    {
        if (!Input.GetKeyDown(KeyCode.Return)) return;
        if (string.IsNullOrWhiteSpace(message)) return;

        CmdSendMessage(inputField.text);
        inputField.text = string.Empty;
    }

    [Command]
    void CmdSendMessage(string message)
    {
        RpcHandleMessage($"[{connectionToClient.connectionId}]: {message}");
    }

    [ClientRpc]
    void RpcHandleMessage(string message)
    {
        OnMessage?.Invoke($"\n{message}");
    }

}
