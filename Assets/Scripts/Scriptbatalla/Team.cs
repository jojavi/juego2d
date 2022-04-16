using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
     public TeamEnum teamEnum {
       get { return team;}
       set { team = value; }
   }

   [SerializeField] TeamEnum team = TeamEnum.MotherNature;
}
