using GTD;

namespace Tests
{
    public class TestGestionnaireGTD
    {
        private GestionnaireGTD _gestionnaireGTD;

        [SetUp]
        public void Setup()
        {
            _gestionnaireGTD = new GestionnaireGTD();
        }

        // Premier test de l'�nonc�
        [Test]
        public void TestActionPosterieurePasDansListe()
        {
            Assert.Pass();
        }

        // Deuxi�me test de l'�nonc�
        [Test]
        public void TestActionVientDansProchaineAction()
        {
            Assert.Pass();
        }

        // Troisi�me test de l'�nonc�
        [Test]
        public void TestSuiviPasseAEntree()
        {
            Assert.Pass();
        }
    }
}