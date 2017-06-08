using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolframAlphaNET;
using WolframAlphaNET.Objects;

namespace calculator
{
    class Wolfram
    {
        public string SolveThis(string info)
        {
            WolframAlpha wolfram = new WolframAlpha("2PPA96-P9K79VET4P");
            QueryResult results = wolfram.Query(info);

            StringBuilder sb = new StringBuilder();
            if (results != null)
            {
                foreach (Pod pod in results.Pods)
                {
                    sb.Append(pod.Title);
                    if (pod.SubPods != null)
                    {
                        foreach (SubPod subPod in pod.SubPods)
                        {
                            sb.Append(subPod.Title);
                            sb.Append(subPod.Plaintext);
                        }
                    }
                }
            }
            return Parse(sb.ToString());
        }

        string Parse(string info)
        {
            if (info.Contains("Decimal"))
                {
                    info = info.Remove(0, info.IndexOf("Decimal") + 7 + 14);
                }
                else if (info.Contains("Result")) info = info.Remove(0, info.IndexOf("Result") + 6);
                else return "неизвестно";
            int i = 0;
            foreach (char ch in info)
            {
                if (!char.IsDigit(ch) && ch != ',' && ch!= '.')
                {
                    info = info.Remove(i,info.Length-i);
                    break;
                }
                i++;
            }
            return info;
        }
    }
}
