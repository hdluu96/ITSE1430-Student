/* Hoa Luu
 * ITSE 1430
 * 10/18/2018
 */

namespace CharacterCreator
{
    public class Character
    {
        public string Name
        {
            get { return _name ?? " "; }
            set { _name = value; }
        }
        private string _name = "";

        public string Profession;
        public string Race;

        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Charisma { get; set; }
    }
}
