using System;

public abstract class FrameWork
{
    public string Typ { get; set; }
    public Relation Relation { get; set; }
    public int? TimeFrame { get; set; }

    public FrameWork(string typ)
    {
        Typ = typ;
        Relation = null;
        TimeFrame = null;
    }

    public void AddRelation(Relation assetBrokerStrategyRelation)
    {
        Relation = assetBrokerStrategyRelation;
    }

    public void SetTimeFrame(int timeFrame)
    {
        TimeFrame = timeFrame;
    }

    public abstract object ToDict();
}