using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetTeleporter : MonoBehaviour
{
    [System.Serializable]
    public class PlanetPoint
    {
        public string planetName;
        public Transform teleportPoint;  // empty transform near planet
        public TextMeshProUGUI infoText;       // text to show after teleport
    }

    [Header("Player Rig / Camera Root")]
    public Transform playerRig;

    [Header("UI Text Element (World or Canvas)")]
    public TextMeshProUGUI infoText;

    [Header("Planets (Set 5 or more)")]
    public PlanetPoint[] planets;

    private void Start()
    {
        if (infoText != null)
            infoText.text = "";
    }

    // Call this from a button, UI, or VR input
    private void OnDrawGizmos()
    {
        if (planets == null) return;
        foreach (var p in planets)
        {
            if (p.teleportPoint != null)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawSphere(p.teleportPoint.position, 0.2f);
            }
        }
    }

    public void TeleportToPlanet(int index)
    {
        if (index < 0 || index >= planets.Length)
        {
            Debug.LogWarning("Invalid teleport index!");
            return;
        }

        PlanetPoint p = planets[index];

        if (p.teleportPoint == null)
        {
            Debug.LogWarning($"{p.planetName} teleport point is missing!");
            return;
        }

        // ---- TELEPORT PLAYER ----
        playerRig.position = p.teleportPoint.position;
        playerRig.rotation = p.teleportPoint.rotation;

        // ---- SHOW PLANET INFO ----
        if (infoText != null)
            infoText.text = $"{p.planetName}\n\n{p.infoText}";
    }
}
