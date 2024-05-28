using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;


namespace ClassLibrary
{
    public class ProjectLijst : IEnumerable, IEnumerator
    {
        public List<Taak> _projectLijst { get; set; }
        public string _name { get; set; }
        int position = -1;

        public ProjectLijst()
        {
            _projectLijst = new List<Taak>();
        }
        public ProjectLijst(string projectName)
        {
            _projectLijst = new List<Taak>();
            _name = projectName;
        }

        public ProjectLijst(List<Taak> list)
        {
            _projectLijst = list;
        }
        public bool MoveNext()
        {
            position++;
            return (position < _projectLijst.Count);
        }

        public void Reset()
        {
            position = -1;
        }
        public void Add(Taak newtaak) { _projectLijst.Add(newtaak); }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public Taak Current
        {
            get
            {
                try
                {
                    return _projectLijst[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ProjectLijst GetEnumerator()
        {
            return new ProjectLijst(_projectLijst);
        }


        public void addTask(Taak newtaak)
        {
            _projectLijst.Add(newtaak);
        }
        public string readAllTaakLabel()
        {
            string returnValue = "";
            foreach (Taak taak in _projectLijst)
            {
                returnValue += Convert.ToString(taak.TaakLabel);
                returnValue += "\n";
            }
            return returnValue;
        }
        public string showName()
        {
            return _name;
        }
        public void writeProjectToJSON()
        {
            string fileName = $"{_name}.json";
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(fileName, jsonString);
        }
        public async void readProjectFromJSON(string JSONNaam)//werkt nog niet
        {

            string fileName = $"{JSONNaam}.json";
            using FileStream openStream = File.OpenRead(fileName);

            ProjectLijst projectFromJSON = new ProjectLijst();
            projectFromJSON = await JsonSerializer.DeserializeAsync<ProjectLijst>(openStream);//Wilt niet. Zegt dat het een abstract/interface/read-only is.
            for (int i = 0; i < projectFromJSON._projectLijst.Count; i++)
            {
                Taak _taak = projectFromJSON._projectLijst[i];
                _projectLijst.Add(_taak);
            }

        }

        public void writeTakenToJSON()
        {

            for (int i = 0; i < _projectLijst.Count; i++)
            {
                string jsonString = "";
                Taak _taak = _projectLijst[i];
                string fileName = $"{_name}{_taak.TaakLabel}.json";
                jsonString += JsonSerializer.Serialize(_taak);
                File.WriteAllText(fileName, jsonString);
            }

            //foreach (Taak _taak in _projectLijst)
            //{
            //    jsonString += JsonSerializer.Serialize(_taak);
            //    //jsonString += ","; 

            //}

            //jsonString += "]";
        }
        public void addTaakFromJSON(string JSONNaam, Taak taakFromJSON)
        {
            string fileName = $"{JSONNaam}.json";
            string jsonString = File.ReadAllText(fileName);
            taakFromJSON = JsonSerializer.Deserialize<Taak>(jsonString);
            _projectLijst.Add(taakFromJSON);
        }

        public void writeProjectToXML()
        {
            FileStream filestream = new FileStream($"{_name}.xml", FileMode.Create);//Moet nog gesloten worden voor readproject
            XmlSerializer projectToXMLSerializer = new XmlSerializer(this.GetType());
            projectToXMLSerializer.Serialize(filestream, this);
        }
        public void readProjectFromXML(string XMLName)
        {
            FileStream filestream = new FileStream($"{XMLName}.xml", FileMode.Open);//Als de file in gebruik is geeft hij error. Kijk naar writeProjectToXML.
            XmlSerializer XMLToProjectSerializer = new XmlSerializer(this.GetType());
            ProjectLijst projectFromXML = new ProjectLijst();
            projectFromXML = (ProjectLijst)XMLToProjectSerializer.Deserialize(filestream);
            _projectLijst = projectFromXML._projectLijst;
        }

        public void WriteProjectToYAML()
        {
            var YAMLserialzer = new Serializer();
            string fileName = $"{_name}.yaml";
            //FileStream filestream = new FileStream($"{_name}.yaml", FileMode.Create);
            string YAMLString = YAMLserialzer.Serialize(this);

            File.WriteAllText(fileName, YAMLString);

        }
        public void ReadProjectFromYAML(string YAMLnaam)
        {
            //FileStream filestream = new FileStream($"{YAMLnaam}.yaml", FileMode.Open);
            //string filestring = Convert.ToString(filestream);
            string fileName = $"{YAMLnaam}.yaml";
            var YAMLDeserialzer = new Deserializer();
            string YAMLString = File.ReadAllText(fileName);
            ProjectLijst projectFromYAML = YAMLDeserialzer.Deserialize<ProjectLijst>(YAMLString);
            _projectLijst = projectFromYAML._projectLijst;
        }
    }
}
