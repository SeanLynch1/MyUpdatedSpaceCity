using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCity
{
    public class MyCityManager : MonoBehaviour
    {
        #region Fields
        private static MyCityManager _instance;

        public BuildingProfile wallProfile;
        public BuildingProfile towerProfile;
        public GameObject buildingPrefab;
        public Transform gridVisPrefab;
        public BuildingProfile[] gameProfileArray;
        public GameObject[] particleEffectPrefab;
        private bool[,,] cityArray = new bool[280, 280, 280];   //increased array size to allow for larger city volume

        public static MyCityManager Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        #region Methods
        #region Unity Methods

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            else
            {
                Destroy(gameObject);
                Debug.LogError("Multiple NavigationCityManager instances in Scene. Destroying clone!");
            };
        }
        void Start()
        {
            //CITY CROWN
            for (int i = -87; i < 88; i += 174)
            {
                //first pitch
                for (int j = -86; j < -7; j += 1)
                {
                    Instantiate(buildingPrefab, new Vector3(i, j + 86, j), Quaternion.identity).GetComponent<SpaceTowerBlock>().SetProfile(wallProfile);
                    Instantiate(particleEffectPrefab[0], new Vector3(i, j +86, j), Quaternion.identity);
                }
                for(int j = -8; j < 9; j++)
                {
                    Instantiate(buildingPrefab, new Vector3(i, 78, j), Quaternion.identity).GetComponent<SpaceTowerBlock>().SetProfile(wallProfile);
                    Instantiate(particleEffectPrefab[0], new Vector3(i, 78, j), Quaternion.identity);
                }
                for(int j = 8; j < 87; j ++)
                {
                    Instantiate(buildingPrefab, new Vector3(i, 86 - j, j), Quaternion.identity).GetComponent<SpaceTowerBlock>().SetProfile(wallProfile);
                    Instantiate(particleEffectPrefab[0], new Vector3(i, 86-j, j), Quaternion.identity);
                }
                //second pitch

                for (int j = -87; j < -7; j += 1)
                {
                    Instantiate(buildingPrefab, new Vector3(j, j + 86, i), Quaternion.identity).GetComponent<SpaceTowerBlock>().SetProfile(wallProfile);
                    Instantiate(particleEffectPrefab[0], new Vector3(j, j + 86, i), Quaternion.identity);
                }
                for (int j = -8; j < 9; j ++)
                {
                    Instantiate(buildingPrefab, new Vector3(j, 78, i), Quaternion.identity).GetComponent<SpaceTowerBlock>().SetProfile(wallProfile);
                    Instantiate(particleEffectPrefab[0], new Vector3(j, 78, i), Quaternion.identity);
                }
                for (int j = 8; j < 87; j++)
                {
                    Instantiate(buildingPrefab, new Vector3(j, 86 - j, i), Quaternion.identity).GetComponent<SpaceTowerBlock>().SetProfile(wallProfile);
                    Instantiate(particleEffectPrefab[0], new Vector3(j, 86-j, i), Quaternion.identity);
                }
            }
            //BUILDING SQUARE
            for(int i = -67; i < 68; i+=134)
            {
                for (int j = -66; j < 67; j += 2)
                {
                    Instantiate(buildingPrefab, new Vector3(i, 100, j), Quaternion.identity).GetComponent<SpaceTowerBlock>().SetProfile(towerProfile);
                    Instantiate(particleEffectPrefab[1], new Vector3(i, 98, j), Quaternion.identity);
                }
                for (int j = -67; j < 68; j +=2)
                {
                    Instantiate(buildingPrefab, new Vector3(j, 100, i - 1), Quaternion.identity).GetComponent<SpaceTowerBlock>().SetProfile(towerProfile);
                    Instantiate(particleEffectPrefab[1], new Vector3(j, 98, i), Quaternion.identity);
                }
            }
            //BUILDING DIAMOND, THIS CRASHES MY GAME FOR SOME REASON
           /* for(int i = 0; i < 80; i -= 1 )
            {
                int randomValue = Random.Range(0, gameProfileArray.Length);
                for (int j = -80; j < 80; j++)
                {
                    Instantiate(buildingPrefab, new Vector3(j - 80, 150, j), Quaternion.identity).GetComponent<SpaceTowerBlock>().SetProfile(gameProfileArray[randomValue]);
                }
            }*/
        }
        #endregion
        //checks if there are slots out of the array
        public bool CheckSlot(int x, int y, int z)
        {
            if (x < 0 || x > 280 || y < 0 || y > 280 || z < 0 || z > 280) return false;
            else
            {
                return cityArray[x, y, z];
            }

        }

        //checks if slots are occupied
        //if so a orange box is built around them
        public void SetSlot(int x, int y, int z, bool occupied)
        {
            if (!(x < 0 || x > 280 || y < 0 || y > 280 || z < 0 || z > 280))
            {
                cityArray[x, y, z] = occupied;
                if (occupied)
                {
                    Instantiate(gridVisPrefab, new Vector3(x -20, y, z -20), Quaternion.identity, SpaceController.Instance.dummyPivot);
                }
            }

        }
        public void BuildTowers(int numTowers)
        {
            for (int i = 0; i < 300; i++)
            {
                int RandomX = Random.Range(-40, 40);
                int RandomZ = Random.Range(-40, 40);
                int RandomY = Random.Range(70, 90);
                int random = Random.Range(0, gameProfileArray.Length);
                if (!((RandomX > -5) && (RandomX < 5) && (RandomZ > -5) && (RandomZ < 5)))
                {
                    Instantiate(buildingPrefab, new Vector3(RandomX, RandomY, RandomZ), Quaternion.identity).GetComponent<SpaceTowerBlock>().SetProfile(gameProfileArray[random]); //Instantiate a random tower from profile array in game controller
                }

            }
           
        }

    }

    #endregion

}
