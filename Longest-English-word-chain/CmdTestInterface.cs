﻿using System;
using System.Collections.Generic;
using Core;
using Library;
namespace Cmd
{
	public class CmdTestInterface
	{
		public CmdTestInterface()
		{
		}

        public static string Solve(string[] args)
        {
            try
            {
                List<string> res = testOneSample(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "";
        }

        public static List<string> testOneSample(string[] args)
        {
            CommandParser parser = new CommandParser(args);
            ParseRes parseRes = parser.getParseRes();
            WordListMaker maker = new WordListMaker();
            string article = maker.getArticleByPath(parseRes.absolutePathOfWordList);
            List<string> wordList = maker.makeWordList(article);
            List<string> result = new List<string>();
            int outputMode = 1;
            if (parseRes.cmdChars.Contains('n'))
            {
                outputMode = 0;
                PairTestInterface.gen_chains_all(wordList, result);
            }
            else if (parseRes.cmdChars.Contains('w'))
            {
                PairTestInterface.gen_chain_word(wordList, result, parseRes.start, parseRes.end, parseRes.enableLoop);
            }
            else if (parseRes.cmdChars.Contains('m'))
            {
                PairTestInterface.gen_chain_word_unique(wordList, result);
            }
            else
            {
                PairTestInterface.gen_chain_char(wordList, result, parseRes.start, parseRes.end, parseRes.enableLoop);
            }
            Output output = new Output();
            output.printWordChains(result, outputMode);
            return result;
        }
    }
}

