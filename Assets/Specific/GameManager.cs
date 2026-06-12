using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	[SerializeField] private GameObject minionModelPrefab;

	[Header("Minion Materials")]
	[SerializeField] private Material minerMaterial;
	[SerializeField] private Material warriorMaterial;
	[SerializeField] private Material farmerMaterial;

	private float food = 10;
	private float minerals = 10;
	private float gems = 0;

	private float playerHP = 10;

	private float enemys = 0;
	private int enemyIncreasingBy = 0;

	private float minionUpdateTimer = 0;
	private float enemyScalingTimer = 0;
	private float minionUpdateInterval = 5;
	private float enemyScalingInterval = 20;

	Dictionary<GameObject, Minion> objectMinionPairs = new Dictionary<GameObject, Minion>();

	GameObject minionObject;
	Vector3 mousePos;
	Minion selectedMinion;
	public delegate void OnUpdateDelegate();
	public static event OnUpdateDelegate OnMinionUpdate;
	public delegate void OnFixedUpdateDelegate();
	public static event OnFixedUpdateDelegate OnFixedUpdate;

	[SerializeField] private TextMeshProUGUI foodText;
	[SerializeField] private TextMeshProUGUI enemyWarriorsText;
	[SerializeField] private TextMeshProUGUI mineralsText;
	[SerializeField] private TextMeshProUGUI gemsText;
	[SerializeField] private TextMeshProUGUI playerHPText;



	private void Awake()
	{
		Instance = this;
		foodText.text = "Food: " + food.ToString();
		mineralsText.text = "Minerals: " + minerals.ToString();
		gemsText.text = "Gems: " + gems.ToString();
		enemyWarriorsText.text = "Enemys: " + enemys.ToString() + "\nIncreasing by: " + enemyIncreasingBy;
	}


	private void Update()
	{
		if (minionUpdateTimer >= minionUpdateInterval)
		{
			OnMinionUpdate?.Invoke();
			minionUpdateTimer = 0;
			ActivateEnemys();
		}
		else
		{
			minionUpdateTimer += Time.deltaTime;
		}

		if (enemyScalingTimer >= enemyScalingInterval)
		{
			ChangeEnemys(enemyIncreasingBy);
			enemyIncreasingBy++;
			ChangeEnemyText();
			enemyScalingTimer = 0;
		}
		else
		{
			enemyScalingTimer += Time.deltaTime;
		}

		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			SelectMinion();
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			selectedMinion = null;
		}
		if (selectedMinion != null)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				SetToMine();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				SetToFarm();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				SetToFight();
			}
		}
	}

	private void SelectMinion()
	{
		selectedMinion = null;
		mousePos = Camera.main.ScreenToWorldPoint(
		new Vector3(Input.mousePosition.x,
		Input.mousePosition.y, 8f));
		Ray ray = new Ray(mousePos, -transform.up);

		if (Physics.Raycast(ray, out RaycastHit hitInfo, 10f))
		{
			foreach (var key in objectMinionPairs.Keys)
			{
				if (hitInfo.collider.gameObject == key)
				{
					selectedMinion = objectMinionPairs[key];
					Debug.Log(selectedMinion.Miniontypes);
				}
			}
			Debug.Log("Hit: " + hitInfo.collider.gameObject.name);
		}
	}

	public void MinionFoodChange(int foodEaten)
	{
		food+= foodEaten;
		foodText.text = "Food: " + food.ToString();
		if (food < 0)
		{
			SceneManager.LoadScene("GameOverFood");
		}
	}

	public void ChangeMinerals(int mineralsGained)
	{
		minerals += mineralsGained;
		mineralsText.text = "Minerals: " + minerals.ToString();
	}

	public void ChangeGems(int gemsGained)
	{
		gems += gemsGained;
		gemsText.text = "Gems: " + gems.ToString();
	}

	public void ChangeEnemyText()
	{
		enemyWarriorsText.text = "Enemies: " + enemys.ToString() + "\nIncreasing by: " + enemyIncreasingBy;
	}
	public void ChangeEnemys(int enemysAdded)
	{
		if (enemys+enemysAdded >= 0)
		{
			enemys += enemysAdded;
		}

		ChangeEnemyText();
	}

	private void ActivateEnemys()
	{
		playerHP -= enemys;
		playerHPText.text = "HP: " + playerHP.ToString();
		if (playerHP <= 0)
		{
			SceneManager.LoadScene("GameOverEnemies");
		}
	}
	private void FixedUpdate()
	{
		OnFixedUpdate?.Invoke();
	}

	private void SetToMine()
	{
		selectedMinion.stateMachine.SetState(new MiningState(selectedMinion));
	}
	private void SetToFight()
	{
		selectedMinion.stateMachine.SetState(new FightingState(selectedMinion));
	}

	private void SetToFarm()
	{
		selectedMinion.stateMachine.SetState(new FarmingState(selectedMinion));
	}

	public void SpawnMiner()
	{
		if (minerals >= 5)
		{
			minionObject = Instantiate(minionModelPrefab);
			minionObject.GetComponent<MeshRenderer>().material = minerMaterial;
			var minionSpawner = new Spawner<Minion>(new MinionFactory());
			var minerDecorator = new MinerDecorator(5, 5);
			var newMinion = minionSpawner.SpawnAtPosition(Vector3.one, minionObject, minerDecorator);
			objectMinionPairs.Add(minionObject, newMinion);
			ChangeMinerals(-5);
		}
	}

	public void SpawnWarrior()
	{
		if (minerals >= 5 && gems >= 5)
		{
			minionObject = Instantiate(minionModelPrefab);
			minionObject.GetComponent<MeshRenderer>().material = warriorMaterial;
			var minionSpawner = new Spawner<Minion>(new MinionFactory());
			var warriorDecorator = new WarriorDecorator(20, 15);
			var newMinion = minionSpawner.SpawnAtPosition(Vector3.one, minionObject, warriorDecorator);
			objectMinionPairs.Add(minionObject, newMinion);
			ChangeMinerals(-5);
			ChangeGems(-2);
		}
	}

	public void SpawnFarmer()
	{
		if (minerals >= 5)
		{
			minionObject = Instantiate(minionModelPrefab);
			minionObject.GetComponent<MeshRenderer>().material = farmerMaterial;
			var minionSpawner = new Spawner<Minion>(new MinionFactory());
			var farmerDecorator = new FarmerDecorator(2, 2);
			var newMinion = minionSpawner.SpawnAtPosition(Vector3.one, minionObject, farmerDecorator);
			objectMinionPairs.Add(minionObject, newMinion);
			ChangeMinerals(-5);

		}
	}
}
