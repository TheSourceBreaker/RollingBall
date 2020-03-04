using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    public int goldCount;
    public int maxGoldCount;
    public int houseGoldCount;
    public float movementSpeed;
    private IDecision currentIDecision;
    IDecision MinerAI;


    public GameObject house; // use seperate house script to get gold from miners altogether
    public GameObject player;
    public GameObject goldMine;

    void Update()
    {
        MinerAI = new IsGoldFull(new AreWeAtBase(new DumpGold(this), new MoveToBase(this), this), new AreWeAtMine(new GatherGold(this), new MoveToMine(this), this), this);

        currentIDecision = MinerAI;

        while (currentIDecision != null)
        {
            currentIDecision = currentIDecision.MakeDecision();
        }
    }


}

public interface IDecision
{
    IDecision MakeDecision();
}

public class IsGoldFull : IDecision
{
    bool value;
    public IDecision trueBranch;
    public IDecision falseBranch;

    public IsGoldFull(IDecision trueBranch, IDecision falseBranch, Miner _miner)
    {
        Debug.Log("Test");
        if (_miner.goldCount >= _miner.maxGoldCount)
        {
            value = true;
            this.trueBranch = trueBranch;
        }
        else
        {
            value = false;
            this.falseBranch = falseBranch;
        }
    }

    public IDecision MakeDecision()
    {
        if(value == true)
            return trueBranch;

        else if(value == false)
            return falseBranch;

        return null;
    }
}

public class AreWeAtBase : IDecision
{
    bool value;
    public IDecision trueBranch;
    public IDecision falseBranch;

    public AreWeAtBase(IDecision trueBranch, IDecision falseBranch, Miner _miner)
    {
        if (Vector3.Distance(_miner.player.transform.position, _miner.house.transform.position) < 0.6)
        {
            value = true;
            this.trueBranch = trueBranch;
        }
        else
        {
            value = false;
            this.falseBranch = falseBranch;
        }
    }

    public IDecision MakeDecision()
    {
        if (value == true)
            return trueBranch;

        else if (value == false)
            return falseBranch;

        return null;
    }
}

public class DumpGold : IDecision
{
    Miner miner;
  
    public DumpGold(Miner _miner)
    {
        miner = _miner;
    }

    public IDecision MakeDecision()
    {
        miner.houseGoldCount = miner.houseGoldCount + miner.goldCount; //Could work with deltaTime
        miner.goldCount = 0;
        return null;
    }
}

public class MoveToBase : IDecision
{
    Miner miner;

    public MoveToBase(Miner _miner)
    {
        miner = _miner;
    }

    public IDecision MakeDecision()
    {
        //Pathfind to base
        //Miner trueminer;
        miner.player.transform.position = Vector3.MoveTowards(miner.player.transform.position, miner.house.transform.position, miner.movementSpeed * Time.deltaTime);
        //trueminer = this.miner;
        return null;
    }
}

public class AreWeAtMine : IDecision
{
    bool value;
    public IDecision trueBranch;
    public IDecision falseBranch;

    public AreWeAtMine(IDecision trueBranch, IDecision falseBranch, Miner _miner)
    {
        if (Vector3.Distance(_miner.player.transform.position, _miner.goldMine.transform.position) < 0.6)
        {
            value = true;
            this.trueBranch = trueBranch;
        }
        else
        {
            value = false;
            this.falseBranch = falseBranch;
        }
    }

    public IDecision MakeDecision()
    {
        if (value == true)
            return trueBranch;

        else if (value == false)
            return falseBranch;

        return null;
    }
}

public class GatherGold : IDecision
{
    Miner miner;

    public GatherGold(Miner _miner)
    {
        miner = _miner;
    }

    public IDecision MakeDecision()
    {
        miner.goldCount = miner.maxGoldCount;
        return null;
    }
}

public class MoveToMine : IDecision
{
    Miner miner;

    public MoveToMine(Miner _miner)
    {
        miner = _miner;
    }

    public IDecision MakeDecision()
    {
        //Pathfind to mine
        miner.player.transform.position = Vector3.MoveTowards(miner.player.transform.position, miner.goldMine.transform.position, miner.movementSpeed * Time.deltaTime);

        return null;
    }
}
