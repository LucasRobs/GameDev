using UnityEngine;

public class PlayerSpellControler : MonoBehaviour
{
  public GameObject[] spells = new GameObject[10];

  private void Start()
  {

  }
  private void Update()
  {

  }
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Spell")
    {
      print("found");
      /* foreach (GameObject spell in spells)
       {
       }*/
      if (other.GetComponent<SpellThunderBall>())
      {
        other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        spells[0] = Instantiate(other.gameObject, transform.position, transform.rotation, transform);

        //GameObject projectile = Instantiate(spells[0], transform.position, transform.rotation);
        Destroy(other.gameObject);

      }
    }
  }
}