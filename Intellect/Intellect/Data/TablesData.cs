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
		public List<string> GrammarInfo { get { return CreateList(gramInfo); } }
		public string[] ComponentRdSentence { get { return componentRdSentence; } }
		public string[] StructureGroupVerb { get { return structureGroupVerb; } }
		public string[] PotentielStructureGroupNoun { get { return potentielStructureGroupNoun; } }

		//таблица окончания
		private string[] myEnds =
		{
			"ами", "ат", "мя", "ям", "его", "ах", "ов", "ят", "емп", "ая", "ев", "ях",
			"ему", "ев", "ой", "яя", "емя", "ее", "ом", "а", "ете", "ей", "ою", "е",
			"ешь", "ем", "ум", "и", "ими", "ет", "ут", "й", "ите", "ох", "ух", "о",
			"ишь", "ею", "ую", "у", "ого", "ие", "ые", "ы", "ому", "ий", "ый", "ь",
			"умя", "им", "ым", "ю", "ыми", "ит", "ых", "я", "ями", "их", "ют", "ть",
			"ам", "ми", "юю",  "ется", "ов", "+"
		};

		//таблица основ слов
		private string[] basis =
		{
			"финал", "момент", "матч","голос", "игрок", "европеец","журналист",
			"команд", "звезд", "наград","лучш", "перв", "двукратн","молод",
			"разн", "единственн","больш", "меньш", "ста", "получив",
			"стал", "игравш", "проигравш", "смог","дв", "кто",
			"кого", "всего","никогда","сам", "у", "из",
			"не", "на", "и", "в"
		};

	
		//таблица грамматическая информация
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
			{"40", "Наречие им./вин падеж"},{"41", "предлог"},{"42", "Ч.родитель.падеж"},{"43", "первое/второе/третье лицо, ед.число"}
			,{"44", "Союзное слово им./п."},{"45", "Союзное слово рд./вн./п."},

		};

		//таблица сокрашения составных частей предложения.
		private string[] componentRdSentence = { "ВГ", "Г", "ГГ", "ГС", "М", "ПД", "ПМ", "ПР", "С", "СЗ" };
		private string[] structureGroupVerb = { "Г", "Г-ПД", "Г-ВГ", };
		private string[] potentielStructureGroupNoun = { "С", "ПР-С", "ПМ-С", "С-С", "ПР-С-С", "С-С-С",
														"С-ПР-С", "ПР-С-ПР-С", "ПР-С-С-С", "С-С-С-С", "С-С-ПР-С" };

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
			for (int i = 0; i < gramInfo.Length / 2; i++)
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
			basisEndInfo[0, 65] = "2";
			basisEndInfo[0,19] = "6";
			basisEndInfo[0, 6] = "27";
			basisEndInfo[1, 65] = "2";
			basisEndInfo[1, 19] = "6";
			basisEndInfo[2, 65] = "2";
			basisEndInfo[2, 23] = "22";
			basisEndInfo[3, 65] = "2";
			basisEndInfo[3, 6] = "27";
			basisEndInfo[4, 65] = "2";
			basisEndInfo[4, 18] = "18";
			basisEndInfo[4, 39] = "15";
			basisEndInfo[4, 19] = "11";
			basisEndInfo[5, 65] = "1";
			basisEndInfo[6, 65] = "1";
			basisEndInfo[6, 6] = "28";
			//2- сущ. жен. рода
			basisEndInfo[7, 65] = "27";
			basisEndInfo[7, 23] = "16";
			basisEndInfo[7, 43] = "26";
			basisEndInfo[7, 5] = "32";
			basisEndInfo[7, 19] = "1";
			basisEndInfo[8, 65] = "27";
			basisEndInfo[8, 19] = "1";
			basisEndInfo[9, 65] = "27";
			basisEndInfo[9, 19] = "1";
			//3- прилагательные
			basisEndInfo[10, 4] = "11";
			basisEndInfo[10, 49] = "18";
			basisEndInfo[10, 45] = "2";
			basisEndInfo[10, 12] = "15";
			basisEndInfo[11, 50] = "18";
			basisEndInfo[11, 46] = "2";
			basisEndInfo[12, 46] = "2";
			basisEndInfo[13, 14] = "2";
			basisEndInfo[14, 54] = "29";
			basisEndInfo[14, 42] = "26";
			basisEndInfo[14, 46] = "2";
			basisEndInfo[15, 46] = "2";
			basisEndInfo[16, 23] = "38";
			basisEndInfo[17, 23] = "38";
			//4- Глаголы в личной форме 33
			basisEndInfo[18, 59] = "35";
			//5- Глаголы в прошедшем времени
			basisEndInfo[19, 65] = "36";
			basisEndInfo[20, 65] = "43";
			basisEndInfo[21, 45] = "35";
			basisEndInfo[22, 21] = "35";
			basisEndInfo[23, 65] = "43";
			//количественные числительные
			basisEndInfo[24, 34] = "41";
			//6- Местоимения
			basisEndInfo[25, 65] = "44";
			basisEndInfo[26, 65] = "45";
			basisEndInfo[27, 65] = "38";
			basisEndInfo[28, 65] = "38";
			basisEndInfo[29, 46] = "2";
			//7-предлоги
			basisEndInfo[30, 65] = "41";
			basisEndInfo[31, 65] = "41";
			basisEndInfo[32, 65] = "41";
			basisEndInfo[33, 65] = "41";
			basisEndInfo[34, 65] = "41";
			basisEndInfo[35, 65] = "41";
			return basisEndInfo;
		}
	}
}
