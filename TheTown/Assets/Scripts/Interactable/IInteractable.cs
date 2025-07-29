using JetBrains.Annotations;

public interface IInteractable
{
    [CanBeNull] public string Name { get; }

    public void OnInteract();
}