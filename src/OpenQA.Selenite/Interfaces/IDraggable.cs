namespace OpenQA.Selenite.Interfaces
{
    public interface IDraggable : IHasBackingElement
    {
        IPerformsDragAndDrop GetDragAndDropPerformer();
    }
}