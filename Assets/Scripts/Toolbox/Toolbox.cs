using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum job
{
    none,
    blacksmith,
    citizen1,
    citizen2,
    citizen3,
    etherLord,
    mercenary1,
    mercenary2,
    mercenary3,
    sandra,
    lohrlynh
}
public class Toolbox
{

    //Jobs for NPCs as enum

    /// <summary>
    /// nomenclature :
    /// priority(3digit)-job(3 letter)-randomID(3digit)
    /// </summary>
    public static string craftIdString(int priority, string job)
    {

        return String.Format("{0}-{1}-{2}", Mathf.Clamp(priority, 0, 999), job, UnityEngine.Random.Range(0, 999));
    }
    
    /// <summary>
    /// get the job enum from the job string.
    /// </summary>
    /// <param name="job">The job.</param>
    /// <returns></returns>
    public static string jobEnumToString(job job)
    {
        string ret = "";
        switch (job)
        {
            case global::job.none:
                ret = "none";
                break;
            case global::job.blacksmith:
                ret = "blacksmith";
                break;
            case global::job.citizen1:
                ret = "citizen1";
                break;
            case global::job.citizen2:
                ret = "citizen2";
                break;
            case global::job.citizen3:
                ret = "citizen3";
                break;
            case global::job.etherLord:
                ret = "etherLord";
                break;
            case global::job.mercenary1:
                ret = "mercenary1";
                break;
            case global::job.mercenary2:
                ret = "mercenary2";
                break;
            case global::job.mercenary3:
                ret = "mercenary3";
                break;
            case global::job.sandra:
                ret = "sandra";
                break;
            case global::job.lohrlynh:
                ret = "lohrlynh";
                break;
            default:
                ret = "none";
                break;
        }
        return ret;
    }

    /// <summary>
    /// get the job string from the job enum.
    /// </summary>
    /// <param name="job">The job.</param>
    /// <returns></returns>
    public static job jobStringToEnum(string job)
    {
        job ret = global::job.none;
        switch (job)
        {
            case "none":
                ret = global::job.none;
                break;
            case "blacksmith":
                ret = global::job.blacksmith;
                break;
            case "citizen1":
                ret = global::job.citizen1;
                break;
            case "citizen2":
                ret = global::job.citizen2;
                break;
            case "citizen3":
                ret = global::job.citizen3;
                break;
            case "etherLord":
                ret = global::job.etherLord;
                break;
            case "mercenary1":
                ret = global::job.mercenary1;
                break;
            case "mercenary2":
                ret = global::job.mercenary2;
                break;
            case "mercenary3":
                ret = global::job.mercenary3;
                break;
            case "sandra":
                ret = global::job.sandra;
                break;
            case "lohrlynh":
                ret = global::job.lohrlynh;
                break;
            default:
                ret = global::job.none;
                break;
        }
        return ret;
    }

    public static int optimizedRand(int min, int max)
    {
        System.Random rnd = new System.Random();
        return rnd.Next(min, max);
    }
}
