using System;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class Config
{
    public string FileName { get; set; }
    private Dictionary<string, string> dict;

    public Config()
    {
         dict = new Dictionary<string, string>();
    }

    public string ConfigFor(string key)
    {
        string value = null;

        if (dict.ContainsKey(key)) return dict[key]; 

        return value;
    }

    public void Add(string Key, string Value)
    {
        dict[Key] = Value;
    }

    public override string ToString()
    {
        string text = "";
        foreach(KeyValuePair<string, string>  pair in dict)
        {
            text += "[" + pair.Key + "] = " + pair.Value + "\r\n";
        }
        return text; 
    }

    static public Config LoadConfig(string FileName)
    {
        Config newConfig = new Config();
        try
        {   // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader(FileName))
            {
                string line = sr.ReadLine();
                string[] entries;
                while (line != null)
                {
                    entries = line.Split('=');

                    if(entries.Length > 1)
                    {
                        newConfig.Add(entries[0].Trim(), entries[1].Trim());
                    }
                    line = sr.ReadLine();
                }

                sr.Close();
            }
        }
        catch (FileNotFoundException fnfe)
        {
            fnfe.ToString();
            Debug.Log("Config file not found\n" + fnfe.ToString());
        }
        catch (Exception e)
        {
            Debug.Log("Can't config file\n" + e.ToString());
        }

        return newConfig;
    }
}

