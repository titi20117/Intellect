using System;
using System.Collections.Generic;
using System.Text;

namespace Intellect.Data
{
    public class TablesData
    {
		public List<string> Ends { get { return CreateList(myEnds); } }
		public List<string> WordBasis { get { return CreateList(basis); } }
		public string[,] TabMophoInfo { get { return CreateTabMorpInfo(CreateList(basis), CreateList(myEnds)); } }
		public List<string> GrammatiInfo { get { return CreateList(gramInfo); } }


		private string[] myEnds =
		{
			"ами", "ат", "мя", "ям", "его", "ах", "ов", "ят", "емп", "ая", "ев", "ях",
			"ему", "ев", "ой", "яя", "емя", "ее", "ом", "а", "ете", "ей", "ою", "е",
			"ешь", "ем", "ум", "и", "ими", "ет", "ут", "й", "ите", "ох", "ух", "о",
			"ишь", "ею", "ую", "у", "ого", "ие", "ые", "ы", "ому", "ий", "ый", "ь",
			"умя", "им", "ым", "ю", "ыми", "ит", "ых", "я", "ями", "их", "ют", "ть",
			"ам", "ми", "юю",  "ется", "ов", "+"
		};

		private string[] basis =
		{
			"билет-+,ы,а,ов-1", "ден-ь,и-1", "час-ов-1","зоопарк-а,+-1", "режим-+-1", "ребенок-+,а-1","пенсионер-+,а,ов-1",
			"цен-а-1", "стоимост-+,ь-1", "касс-а,ы,е-1","продаж-а,е-1", "работ-а,ы-1", "наличи-е,и-1","дет-и,ей-1",
			"будн-ие,ий-2", "рабоч-ие,ий-2","выходн-ой,ые-2", "взросл-ый-ого,ых-2", "маленьк-ий,их,ого-2", "детск-ий,ого-2",
			"социальн-ый,ого-2", "пенсионн-ый,ого-2", "льготн-ый,ого-2", "сто-ь,ят,ит,-3","ест-ь-3", "работа-ть,ет-3",
			"открыва-ется,ть,ют-3", "закрыва-ется,ть,ют-3","как-+,ов,ой,ие-4","сколько-+-4", "в-+-5", "во-+-5",
			"для-+-5", "ли-+-5", "18-+-6"
		};

	

		public string[,] gramInfo =
		{
			{ "1", "11-ед.число:именительный падеж" }, {"2", "11,14-ед.число:именительный падеж/винительный падеж" }, 
			{ "3", "11,14,16-ед.число:им./вин.падеж, предл.падеж" }, {"4", "11,14,22-ед.число:им./вин.падеж; мн.число:им.падеж" }, 
			{ "5", "11,22,24-ед.число:им.падеж; мн.число:род./вин.падеж" }, {"6", "12-ед.число:род.падеж" }, 
			{ "7", "12,13,15,16-ед.число:род./дат./вин./твор.падеж" }, {"8", "12,13,16-ед.число:род./дат./пред.падеж" },
			{ "9", "12,13,16,21-ед.число:род./дат./пред.падеж; мн.число:им.число:им.падеж" },
			{"10", "12,13,16,21,24-ед.число:род./дат./пред.падеж; мн.число:им.число:им./вин.падеж" }, 
			{ "11", "12,14-ед.число:род./вин.падеж" }, {"12", "12,14,21-ед.число:род./вин.падеж; мн.число:им.падеж" },
			{ "13", "12,21-ед.число:род.падеж; мн.число:им.падеж" }, {"14", "12,21,24-ед.число:род.падеж; мн.число:им./вин.падеж" },
			{ "15", "13-ед.число:дат.падеж" }, {"16", "13,16-ед.число:дат./предл.падеж" },
			{ "17", "14-ед.число:вин.падеж" }, {"18", "15-ед.число:твор.падеж" },
			{ "19", "15,22-ед.число:твор.падеж; мн.число:род.падеж" },
			{"20", "15,22,24-ед.число:твор.падеж; мн.число:род./вин.падеж" },
			{ "21", "15,23-ед.число:твор.падеж; мн.число:дат.падеж" }, {"22", "16-ед.число:пред.падеж" }, 
			{ "23", "16,21-ед.число:пред.падеж; мн.число:им.падеж" }, {"24", "16,21,24-ед.число:пред.падеж; мн.число:им./вин.падеж" },
			{ "25", "21-мн.число:им.падеж" }, {"26", "21,24-мн.число:им./вин.падеж" }, 
			{ "27", "22-мн.число:род.падеж" }, {"28", "22,24-мн.число:род./вин.падеж" },
			{ "29", "22,24,26-мн.число:род./вин./пред.падеж" }, {"30", "23-мн.число:дат.падеж" },
			{ "31", "25-мн.число:твор.падеж" }, {"32", "26-мн.число:пред.падеж" },
			{"33", "третье лицо, ед.число"}, {"34", "третье лицо, мн.число"}, {"35", "первое спряжение"},
			{"36", "второе спряжение"},{"37", "архайческий"},{"38", "Наречие"}, {"39", "прилагательное"},
			{"40", "Наречие им./вин падеж"},{"41", "предлог"},{"42", "Число"}

		};

		private List<string> CreateList(string[] elsWords)
		{
			List<string> result = new List<string>();
			foreach (string el in elsWords)
				result.Add(el);
			return result;
		}

		private List<string> CreateList(string[,] gramInfo)
		{
			List<string> result = new List<string>();
			for (int i = 0; i < gramInfo.Length; i++)
			{
				result.Add(gramInfo[i,1]);
			}
			return result;
		}

		private string[,] CreateTabMorpInfo(List<string> basis, List<string> ends)
		{
			string[,] basisEndInfo;
			basisEndInfo = new string[basis.Count, ends.Count]; 
			for (int i = 0; i<basis.Count; i++) { 
				for (int j = 0; j<ends.Count; j++) {
            		basisEndInfo[i,j] = "";
				}
			}

			//0-basis,19-ends: 14grammaInfo
			//1- сущ. муж. рода
			basisEndInfo[0, 43] = "26";
			basisEndInfo[0,19] = "14";
			basisEndInfo[0, 6] = "27";
			basisEndInfo[1, 47] = "2";
			basisEndInfo[1, 27] = "26";
			basisEndInfo[2, 6] = "27";
			basisEndInfo[3, 19] = "14";
			basisEndInfo[3, 65] = "2";
			basisEndInfo[4, 65] = "2";
			basisEndInfo[5, 65] = "2";
			basisEndInfo[5, 19] = "14";
			basisEndInfo[6, 65] = "2";
			basisEndInfo[6, 19] = "14";
			basisEndInfo[6, 6] = "27";
			//2- сущ. жен. рода
			basisEndInfo[7, 19] = "1";
			basisEndInfo[8, 47] = "1";
			basisEndInfo[9, 19] = "1";
			basisEndInfo[9, 43] = "14";
			basisEndInfo[9, 23] = "16";
			basisEndInfo[10, 19] = "1";
			basisEndInfo[10, 23] = "16";
			basisEndInfo[11, 19] = "1";
			basisEndInfo[11, 43] = "14";
			//3- сущ. сред. рода
			basisEndInfo[12, 23] = "2";
			basisEndInfo[12, 27] = "22";
			//4- сущ.мно.
			basisEndInfo[13, 27] = "25";
			basisEndInfo[13, 21] = "28";
			//5- прилагательные
			basisEndInfo[14, 41] = "25";
			basisEndInfo[14, 45] = "2";
			basisEndInfo[15, 41] = "25";
			basisEndInfo[15, 45] = "1";
			basisEndInfo[16, 14] = "2";
			basisEndInfo[16, 42] = "26";
			basisEndInfo[17, 46] = "2";
			basisEndInfo[17, 40] = "6";
			basisEndInfo[17, 54] = "29";
			basisEndInfo[18, 45] = "2";
			basisEndInfo[18, 57] = "29";
			basisEndInfo[18, 40] = "6";
			basisEndInfo[19, 45] = "2";
			basisEndInfo[19, 40] = "6";
			basisEndInfo[20, 46] = "2";
			basisEndInfo[20, 40] = "6";
			basisEndInfo[21, 46] = "2";
			basisEndInfo[21, 40] = "6";
			basisEndInfo[22, 46] = "2";
			basisEndInfo[22, 40] = "6";
			//6- Глаголы в личной форме 33
			basisEndInfo[23, 47] = "36";
			basisEndInfo[23, 7] = "34";
			basisEndInfo[23, 53] = "33";
			basisEndInfo[24, 47] = "37";
			basisEndInfo[25, 59] = "35";
			basisEndInfo[25, 29] = "33";
			basisEndInfo[26, 63] = "33";
			basisEndInfo[26, 59] = "35";
			basisEndInfo[26, 58] = "34";
			basisEndInfo[27, 63] = "33";
			basisEndInfo[27, 59] = "35";
			basisEndInfo[27, 58] = "34";
			//7- Местоимения
			basisEndInfo[28, 65] = "38";
			basisEndInfo[28, 6] = "39";
			basisEndInfo[28, 14] = "2";
			basisEndInfo[28, 41] = "26";
			basisEndInfo[29, 65] = "40";
			basisEndInfo[30, 65] = "41";
			basisEndInfo[31, 65] = "41";
			basisEndInfo[32, 65] = "41";
			basisEndInfo[33, 65] = "41";
			basisEndInfo[34, 65] = "42";

			return basisEndInfo;
		}
	}
}
