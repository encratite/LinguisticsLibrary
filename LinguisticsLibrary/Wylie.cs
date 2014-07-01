using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LinguisticsLibrary
{
	enum WylieTone
	{
		Low,
		High,
	}

	class WylieOnset
	{
		public readonly string Wylie;
		public readonly string Xsampa;
		public readonly WylieTone Tone;

		public WylieOnset(string wylie, string xsampa, WylieTone tone)
		{
			Wylie = wylie;
			Xsampa = xsampa;
			Tone = tone;
		}
	}

	class WylieFinal
	{
		public readonly string Wylie;
		public readonly string Xsampa;

		public WylieFinal(string wylie, string xsampa)
		{
			Wylie = wylie;
			Xsampa = xsampa;
		}
	}

	public static class Wylie
	{
		static WylieOnset[] Onsets = new []
		{
			new WylieOnset("'khr", "t`_h", WylieTone.High),
			new WylieOnset("'khy", "c_h", WylieTone.High),
			new WylieOnset("'phr", "t`_h", WylieTone.High),
			new WylieOnset("'phy", "ts\\_h", WylieTone.High),
			new WylieOnset("'tsh", "ts_h", WylieTone.High),
			new WylieOnset("brdz", "ts", WylieTone.Low),
			new WylieOnset("brgy", "J\\", WylieTone.Low),
			new WylieOnset("brky", "c", WylieTone.High),
			new WylieOnset("brng", "N", WylieTone.High),
			new WylieOnset("brny", "J", WylieTone.High),
			new WylieOnset("brts", "ts", WylieTone.High),
			new WylieOnset("bsgr", "t`", WylieTone.Low),
			new WylieOnset("bsgy", "J\\", WylieTone.Low),
			new WylieOnset("bskr", "t`", WylieTone.High),
			new WylieOnset("bsky", "c", WylieTone.High),
			new WylieOnset("bsng", "N", WylieTone.High),
			new WylieOnset("bsny", "J", WylieTone.High),
			new WylieOnset("bsts", "ts", WylieTone.High),
			new WylieOnset("mkhr", "t`_h", WylieTone.High),
			new WylieOnset("mkhy", "c_h", WylieTone.High),
			new WylieOnset("mtsh", "ts_h", WylieTone.High),
			new WylieOnset("rtsw", "ts", WylieTone.High),
			new WylieOnset("stsw", "ts", WylieTone.High),
			new WylieOnset("tshw", "ts_h", WylieTone.High),
			new WylieOnset("'br", "n`t`", WylieTone.Low),
			new WylieOnset("'by", "Jts\\", WylieTone.Low),
			new WylieOnset("'ch", "ts\\_h", WylieTone.High),
			new WylieOnset("'dr", "n`t`", WylieTone.Low),
			new WylieOnset("'dz", "nts", WylieTone.Low),
			new WylieOnset("'gr", "n`t`", WylieTone.Low),
			new WylieOnset("'gy", "Jc", WylieTone.Low),
			new WylieOnset("'kh", "k_h", WylieTone.High),
			new WylieOnset("'ph", "p_h", WylieTone.High),
			new WylieOnset("'th", "t_h", WylieTone.High),
			new WylieOnset("bgy", "J\\", WylieTone.Low),
			new WylieOnset("bkr", "t`", WylieTone.High),
			new WylieOnset("bky", "c", WylieTone.High),
			new WylieOnset("bld", "t", WylieTone.High),
			new WylieOnset("blt", "t", WylieTone.High),
			new WylieOnset("brd", "d", WylieTone.Low),
			new WylieOnset("brg", "g", WylieTone.Low),
			new WylieOnset("brj", "ts\\", WylieTone.Low),
			new WylieOnset("brk", "k", WylieTone.High),
			new WylieOnset("brl", "l", WylieTone.High),
			new WylieOnset("brn", "n", WylieTone.High),
			new WylieOnset("brt", "t", WylieTone.High),
			new WylieOnset("bsd", "d", WylieTone.Low),
			new WylieOnset("bsg", "g", WylieTone.Low),
			new WylieOnset("bsh", "s\\", WylieTone.High),
			new WylieOnset("bsk", "k", WylieTone.High),
			new WylieOnset("bsl", "l", WylieTone.High),
			new WylieOnset("bsn", "n", WylieTone.High),
			new WylieOnset("bsr", "t`", WylieTone.High),
			new WylieOnset("bsr", "s", WylieTone.High),
			new WylieOnset("bst", "t", WylieTone.High),
			new WylieOnset("bts", "ts", WylieTone.High),
			new WylieOnset("bzh", "s\\", WylieTone.Low),
			new WylieOnset("bzl", "nt", WylieTone.Low),
			new WylieOnset("dbr", "t`", WylieTone.Low),
			new WylieOnset("dby", "ts\\", WylieTone.Low),
			new WylieOnset("dgr", "t`", WylieTone.Low),
			new WylieOnset("dgy", "J\\", WylieTone.Low),
			new WylieOnset("dkr", "t`", WylieTone.High),
			new WylieOnset("dky", "c", WylieTone.High),
			new WylieOnset("dng", "N", WylieTone.High),
			new WylieOnset("dpr", "t`", WylieTone.High),
			new WylieOnset("dpy", "ts\\", WylieTone.High),
			new WylieOnset("g.y", "j", WylieTone.High),
			new WylieOnset("gdz", "ts", WylieTone.Low),
			new WylieOnset("gny", "J", WylieTone.High),
			new WylieOnset("grw", "t`_h", WylieTone.Low),
			new WylieOnset("gsh", "s\\", WylieTone.High),
			new WylieOnset("gts", "ts", WylieTone.High),
			new WylieOnset("gzh", "s\\", WylieTone.Low),
			new WylieOnset("khr", "t`_h", WylieTone.High),
			new WylieOnset("khw", "k_h", WylieTone.High),
			new WylieOnset("khy", "c_h", WylieTone.High),
			new WylieOnset("lbr", "t`", WylieTone.Low),
			new WylieOnset("lby", "ts\\", WylieTone.Low),
			new WylieOnset("lgr", "t`", WylieTone.Low),
			new WylieOnset("lgy", "J\\", WylieTone.Low),
			new WylieOnset("lkr", "t`", WylieTone.High),
			new WylieOnset("lky", "c", WylieTone.High),
			new WylieOnset("lng", "N", WylieTone.High),
			new WylieOnset("lpr", "t`", WylieTone.High),
			new WylieOnset("lpy", "ts\\", WylieTone.High),
			new WylieOnset("lth", "nt", WylieTone.High),
			new WylieOnset("mch", "ts\\_h", WylieTone.High),
			new WylieOnset("mdz", "nts", WylieTone.Low),
			new WylieOnset("mgr", "n`t`", WylieTone.Low),
			new WylieOnset("mgy", "Jc", WylieTone.Low),
			new WylieOnset("mkh", "k_h", WylieTone.High),
			new WylieOnset("mng", "N", WylieTone.High),
			new WylieOnset("mny", "J", WylieTone.High),
			new WylieOnset("mth", "t_h", WylieTone.High),
			new WylieOnset("nyw", "J", WylieTone.High),
			new WylieOnset("phr", "t`_h", WylieTone.High),
			new WylieOnset("phy", "ts\\_h", WylieTone.High),
			new WylieOnset("rbr", "t`", WylieTone.Low),
			new WylieOnset("rby", "ts\\", WylieTone.Low),
			new WylieOnset("rdz", "ts", WylieTone.Low),
			new WylieOnset("rgr", "t`", WylieTone.Low),
			new WylieOnset("rgy", "J\\", WylieTone.Low),
			new WylieOnset("rkr", "t`", WylieTone.High),
			new WylieOnset("rky", "c", WylieTone.High),
			new WylieOnset("rmy", "J", WylieTone.High),
			new WylieOnset("rng", "N", WylieTone.High),
			new WylieOnset("rny", "J", WylieTone.High),
			new WylieOnset("rts", "ts", WylieTone.High),
			new WylieOnset("sbr", "t`", WylieTone.Low),
			new WylieOnset("sbr", "b", WylieTone.Low),
			new WylieOnset("sby", "ts\\", WylieTone.Low),
			new WylieOnset("sgr", "t`", WylieTone.Low),
			new WylieOnset("sgy", "J\\", WylieTone.Low),
			new WylieOnset("shw", "s\\", WylieTone.High),
			new WylieOnset("skr", "t`", WylieTone.High),
			new WylieOnset("sky", "c", WylieTone.High),
			new WylieOnset("smr", "m", WylieTone.High),
			new WylieOnset("smy", "J", WylieTone.High),
			new WylieOnset("sng", "N", WylieTone.High),
			new WylieOnset("sny", "J", WylieTone.High),
			new WylieOnset("spr", "t`", WylieTone.High),
			new WylieOnset("spy", "ts\\", WylieTone.High),
			new WylieOnset("sts", "ts", WylieTone.High),
			new WylieOnset("thr", "t`_h", WylieTone.High),
			new WylieOnset("tsh", "ts_h", WylieTone.High),
			new WylieOnset("zhw", "s\\", WylieTone.Low),
			new WylieOnset("'b", "mp", WylieTone.Low),
			new WylieOnset("'d", "nt", WylieTone.Low),
			new WylieOnset("'g", "Nk", WylieTone.Low),
			new WylieOnset("'j", "Jts\\", WylieTone.Low),
			new WylieOnset("bc", "ts\\", WylieTone.High),
			new WylieOnset("bd", "d", WylieTone.Low),
			new WylieOnset("bg", "g", WylieTone.Low),
			new WylieOnset("bk", "k", WylieTone.High),
			new WylieOnset("bl", "l", WylieTone.High),
			new WylieOnset("br", "t`_h", WylieTone.Low),
			new WylieOnset("bs", "s", WylieTone.High),
			new WylieOnset("bt", "t", WylieTone.High),
			new WylieOnset("by", "ts\\_h", WylieTone.Low),
			new WylieOnset("bz", "s", WylieTone.Low),
			new WylieOnset("ch", "ts\\_h", WylieTone.High),
			new WylieOnset("cw", "ts\\", WylieTone.High),
			new WylieOnset("db", "?", WylieTone.High),
			new WylieOnset("db", "w", WylieTone.Low),
			new WylieOnset("dg", "g", WylieTone.Low),
			new WylieOnset("dk", "k", WylieTone.High),
			new WylieOnset("dm", "m", WylieTone.High),
			new WylieOnset("dp", "p", WylieTone.High),
			new WylieOnset("dr", "t`_h", WylieTone.Low),
			new WylieOnset("dw", "t_h", WylieTone.Low),
			new WylieOnset("dz", "ts_h", WylieTone.Low),
			new WylieOnset("gc", "ts\\", WylieTone.High),
			new WylieOnset("gd", "d", WylieTone.Low),
			new WylieOnset("gj", "ts\\", WylieTone.Low),
			new WylieOnset("gl", "l", WylieTone.High),
			new WylieOnset("gn", "n", WylieTone.High),
			new WylieOnset("gr", "t`_h", WylieTone.Low),
			new WylieOnset("gs", "s", WylieTone.High),
			new WylieOnset("gt", "t", WylieTone.High),
			new WylieOnset("gw", "k_h", WylieTone.Low),
			new WylieOnset("gy", "c_h", WylieTone.Low),
			new WylieOnset("gz", "s", WylieTone.Low),
			new WylieOnset("hr", "s`", WylieTone.High),
			new WylieOnset("hw", "h", WylieTone.High),
			new WylieOnset("kh", "k_h", WylieTone.High),
			new WylieOnset("kl", "l", WylieTone.High),
			new WylieOnset("kr", "t`", WylieTone.High),
			new WylieOnset("kw", "k", WylieTone.High),
			new WylieOnset("ky", "c", WylieTone.High),
			new WylieOnset("lb", "mp", WylieTone.Low),
			new WylieOnset("lc", "ts\\", WylieTone.High),
			new WylieOnset("ld", "nt", WylieTone.Low),
			new WylieOnset("lg", "g", WylieTone.Low),
			new WylieOnset("lg", "Nk", WylieTone.Low),
			new WylieOnset("lh", "K", WylieTone.High),
			new WylieOnset("lj", "Jts\\", WylieTone.Low),
			new WylieOnset("lk", "k", WylieTone.High),
			new WylieOnset("lp", "p", WylieTone.High),
			new WylieOnset("lt", "t", WylieTone.High),
			new WylieOnset("lw", "l", WylieTone.Low),
			new WylieOnset("md", "nt", WylieTone.Low),
			new WylieOnset("mg", "Nk", WylieTone.Low),
			new WylieOnset("mj", "Jts\\", WylieTone.Low),
			new WylieOnset("mn", "n", WylieTone.High),
			new WylieOnset("mr", "m", WylieTone.Low),
			new WylieOnset("my", "J", WylieTone.Low),
			new WylieOnset("ng", "N", WylieTone.Low),
			new WylieOnset("ny", "J", WylieTone.Low),
			new WylieOnset("ph", "p_h", WylieTone.High),
			new WylieOnset("pr", "t`", WylieTone.High),
			new WylieOnset("py", "ts\\", WylieTone.High),
			new WylieOnset("rb", "b", WylieTone.Low),
			new WylieOnset("rd", "d", WylieTone.Low),
			new WylieOnset("rg", "g", WylieTone.Low),
			new WylieOnset("rj", "ts\\", WylieTone.Low),
			new WylieOnset("rk", "k", WylieTone.High),
			new WylieOnset("rl", "l", WylieTone.High),
			new WylieOnset("rm", "m", WylieTone.High),
			new WylieOnset("rn", "n", WylieTone.High),
			new WylieOnset("rt", "t", WylieTone.High),
			new WylieOnset("rw", "r", WylieTone.Low),
			new WylieOnset("sb", "b", WylieTone.Low),
			new WylieOnset("sd", "d", WylieTone.Low),
			new WylieOnset("sg", "g", WylieTone.Low),
			new WylieOnset("sh", "s\\", WylieTone.High),
			new WylieOnset("sk", "k", WylieTone.High),
			new WylieOnset("sl", "l", WylieTone.High),
			new WylieOnset("sm", "m", WylieTone.High),
			new WylieOnset("sn", "n", WylieTone.High),
			new WylieOnset("sp", "p", WylieTone.High),
			new WylieOnset("sr", "s", WylieTone.High),
			new WylieOnset("st", "t", WylieTone.High),
			new WylieOnset("sw", "s", WylieTone.High),
			new WylieOnset("th", "t_h", WylieTone.High),
			new WylieOnset("tr", "t`", WylieTone.High),
			new WylieOnset("ts", "ts", WylieTone.High),
			new WylieOnset("tw", "t", WylieTone.High),
			new WylieOnset("zh", "s\\", WylieTone.Low),
			new WylieOnset("zl", "nt", WylieTone.Low),
			new WylieOnset("zw", "s", WylieTone.Low),
			new WylieOnset("'", "?", WylieTone.Low),
			new WylieOnset("b", "p_h", WylieTone.Low),
			new WylieOnset("b", "w", WylieTone.Low),
			new WylieOnset("c", "ts\\", WylieTone.High),
			new WylieOnset("d", "t_h", WylieTone.Low),
			new WylieOnset("g", "k_h", WylieTone.Low),
			new WylieOnset("h", "h", WylieTone.High),
			new WylieOnset("j", "ts\\_h", WylieTone.Low),
			new WylieOnset("k", "k", WylieTone.High),
			new WylieOnset("l", "l", WylieTone.Low),
			new WylieOnset("m", "m", WylieTone.Low),
			new WylieOnset("n", "n", WylieTone.Low),
			new WylieOnset("p", "p", WylieTone.High),
			new WylieOnset("r", "r", WylieTone.Low),
			new WylieOnset("s", "s", WylieTone.High),
			new WylieOnset("t", "t", WylieTone.High),
			new WylieOnset("w", "w", WylieTone.Low),
			new WylieOnset("y", "j", WylieTone.Low),
			new WylieOnset("z", "s", WylieTone.Low),

			new WylieOnset("dy", "j", WylieTone.Low),
		};

		static WylieFinal[] Finals = new []
		{
			new WylieFinal("s", "?"),
			new WylieFinal("b", "p"),
			new WylieFinal("d", "?"),
			new WylieFinal("g", "?"),
			new WylieFinal("n", "~"),
			new WylieFinal("r", ":"),
			new WylieFinal("m", "m"),
			new WylieFinal("'i", ":"),
			// Not sure
			new WylieFinal("l", "l"),
			new WylieFinal("ng", "N"),

			// Not sure
			new WylieFinal("ms", "m"),
			new WylieFinal("ps", "p_h"),
			new WylieFinal("bs", "p"),
			new WylieFinal("gs", "k"),
			new WylieFinal("ngs", "N"),
		};

		public static string ToXsampa(string wylieInput)
		{
			string pattern = "([a-z']+?)([aeiou])([a-z']+)?";
			string output = Regex.Replace(wylieInput, pattern, EvaluateMatch);
			return output;
		}

		static string EvaluateMatch(Match match)
		{
			string input = match.Value;
			var groups = match.Groups;
			string onset = groups[1].Value;
			string vowel = groups[2].Value;
			var finalGroup = groups[3];
			var wylieOnset = Onsets.FirstOrDefault(x => x.Wylie == onset);
			if (wylieOnset == null)
				throw new ArgumentException(string.Format("Unknown onset: {0}", input));
			string output = wylieOnset.Xsampa + vowel;
			if (finalGroup.Success)
			{
				string final = finalGroup.Value;
				var wylieFinal = Finals.FirstOrDefault(x => x.Wylie == final);
				if(wylieFinal == null)
					throw new ArgumentException(string.Format("Unknown final: {0}", input));
			}
			output += wylieOnset.Tone == WylieTone.Low ? "_L" : "_H";
			return output;
		}
	}
}
