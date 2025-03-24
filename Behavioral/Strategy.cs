public class SortingContext
{
    private ISortingAlgorithm mySortingAlgorithm;

    public SortingContext(ISortingAlgorithm mySortingAlgorithm)
    {
        this.mySortingAlgorithm = mySortingAlgorithm;
    }

    public void SetSortingAlgorithm(ISortingAlgorithm mySortingAlgorithm)
    {
        this.mySortingAlgorithm = mySortingAlgorithm;
    }

    public void PerforSort(int[] nums)
    {
        mySortingAlgorithm.Sort(nums);
    }
}

public interface ISortingAlgorithm
{
    void Sort(int[] nums);
}

public class BubbleSort : ISortingAlgorithm
{
    public void Sort(int[] nums)
    {
        Console.WriteLine("BubbleSort");
    }
}

public class MergeSort : ISortingAlgorithm
{
    public void Sort(int[] nums)
    {
        Console.WriteLine("MergeSort");
    }
}

public class QuickSort : ISortingAlgorithm
{
    public void Sort(int[] nums)
    {
        Console.WriteLine("QuickSort");
    }
}

internal class StrategyPattern
{
    public void Main()
    {
        var sortingContext = new SortingContext(new BubbleSort());
        sortingContext.PerforSort(new int[] { 1, 2, 3 });

        sortingContext.SetSortingAlgorithm(new MergeSort());
        sortingContext.PerforSort(new int[] { 2, 3, 1, 6, 5 });

        sortingContext.SetSortingAlgorithm(new QuickSort());
        sortingContext.PerforSort(new int[] { 2, 3, 1, 6, 5 });
    }
}