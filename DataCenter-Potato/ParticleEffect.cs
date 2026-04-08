using MelonLoader;
using Unity.Entities;
using Unity.Rendering; 
using UnityEngine;
using UnityEngine.InputSystem; 
using Il2Cpp; 

[assembly: MelonInfo(typeof(DataCenter_Potato.ParticleEffect), "Potato Mod", "1.7.0", "ASavageSwan")]
[assembly: MelonGame("Waseku", "Data Center")]

namespace DataCenter_Potato;

internal sealed class ParticleEffect : MelonMod
{
    private static bool _disableParticles = true;
    private float _keyCooldown = 0f;

    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg("Potato Mod loaded. Press M to toggle packet visibility.");
    }

    public override void OnUpdate()
    {
        _keyCooldown -= Time.deltaTime;
        
        if (Keyboard.current != null && Keyboard.current.mKey.isPressed && _keyCooldown <= 0f)
        {
            _keyCooldown = 0.5f; 
            _disableParticles = !_disableParticles;
            
            LoggerInstance.Msg($"[Potato Mod] Packets Disabled: {_disableParticles}");

            if (!_disableParticles)
            {
                ToggleRendering(hide: false);
            }
        }
    }

    public override void OnLateUpdate()
    {
        if (_disableParticles)
        {
            // Continually sweep just in case the game generates a new blueprint
            ToggleRendering(hide: true);
        }
    }

    private void ToggleRendering(bool hide)
    {
        var world = World.DefaultGameObjectInjectionWorld;
        if (world == null) return;

        var em = world.EntityManager;
        
        if (hide)
        {
            // 1. SWEEP ACTIVE PACKETS
            var activeQuery = em.CreateEntityQuery(
                ComponentType.ReadOnly<PacketComponent>(),
                ComponentType.Exclude<DisableRendering>(),
                ComponentType.Exclude<Prefab>()
            );
            
            if (activeQuery.CalculateEntityCount() > 0)
            {
                em.AddComponent<DisableRendering>(activeQuery);
            }
            
            // We explicitly tell the query to look for the hidden Prefab entity
            var prefabQuery = em.CreateEntityQuery(
                ComponentType.ReadOnly<PacketComponent>(),
                ComponentType.ReadOnly<Prefab>(),
                ComponentType.Exclude<DisableRendering>()
            );
            
            if (prefabQuery.CalculateEntityCount() > 0)
            {
                em.AddComponent<DisableRendering>(prefabQuery);
                // If you see this in your log, it means we successfully infected the source!
                LoggerInstance.Msg("[Potato Mod] Source Prefab Blueprint infected! Flicker eliminated.");
            }
        }
        else
        {
            // RESTORE ACTIVE PACKETS
            var activeQuery = em.CreateEntityQuery(
                ComponentType.ReadOnly<PacketComponent>(),
                ComponentType.ReadOnly<DisableRendering>(),
                ComponentType.Exclude<Prefab>()
            );
            if (activeQuery.CalculateEntityCount() > 0)
                em.RemoveComponent<DisableRendering>(activeQuery);

            // RESTORE PREFAB BLUEPRINT
            var prefabQuery = em.CreateEntityQuery(
                ComponentType.ReadOnly<PacketComponent>(),
                ComponentType.ReadOnly<Prefab>(),
                ComponentType.ReadOnly<DisableRendering>()
            );
            if (prefabQuery.CalculateEntityCount() > 0)
                em.RemoveComponent<DisableRendering>(prefabQuery);
        }
    }
}