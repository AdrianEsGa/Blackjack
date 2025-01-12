using Shared;

namespace Client.Core;

public class Engine
{
    private GameInfo? _gameInfo;
    private readonly Guid _playerId;

    public Engine(Guid playerId)
    {
        _playerId = playerId;
    }

    public bool IsPlaying() => _gameInfo?.Status == PlayerStatus.Playing;

    public bool IsInRoom() => _gameInfo?.Room is not null;

    public void FindRoom()
    {
        Send(BuildRequest(ActionType.FindRoom));
    }

    public void TakeCard()
    {
        Send(BuildRequest(ActionType.TakeCard));
    }

    public void Skip()
    {
        Send(BuildRequest(ActionType.SkipTurn));
    }

    public void OutRoom()
    {
        if(!IsInRoom())
            return;

        Send(BuildRequest(ActionType.OutRoom));
    }

    public void CheckTurn()
    {
        if (!IsInRoom())
            return;

        Send(BuildRequest(ActionType.RefreshGame));
    }

    public void StartNewGame()
    {
        if (!IsInRoom())
            return;

        Send(BuildRequest(ActionType.StartNewGame));
    }

    public void Receive(ServerResponse serverResponse)
    {
        if (serverResponse.Status == ResponseStatus.Success)
        {
            _gameInfo = serverResponse.GameInfo;
            return;
        }

        MessageBox.Show(serverResponse.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void Send(ClientRequest request)
    {
        var response = ClientInstance.Send(request);
        Receive(response);
    }

    public GameInfo GetGameInfo()
    {
        return _gameInfo;
    }

    private ClientRequest BuildRequest(ActionType action)
    {
        return new ClientRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            PlayerId = _playerId.ToString(),
            RoomId = _gameInfo?.Room?.Indentifier,
            Action = action
        };
    }
}
