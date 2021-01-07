using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] GameObject equipedPrefab = null;
        [SerializeField] Projectile projectile = null;

        [SerializeField] bool isRightHanded = true;

        [SerializeField] float weaponDamage = 5f;
        [SerializeField] float weaponRange = 2f;

        public void Spawn(Transform leftHandTransform, Transform rightHandTransform, Animator animator)
        {
            if (equipedPrefab != null) Instantiate(equipedPrefab, isRightHanded ? rightHandTransform : leftHandTransform);
            if (animatorOverride != null) animator.runtimeAnimatorController = animatorOverride;
        }

        public void LaunchProjectile(Transform leftHandTransform, Transform rightHandTransform, Health target)
        {
            Projectile projectileInstance = Instantiate(projectile,
                isRightHanded ? rightHandTransform.position : leftHandTransform.position, Quaternion.identity);
            projectileInstance.SetTarget(target, weaponDamage);
        }

        public bool hasProjectile()
        {
            return projectile != null;
        }

        public float getWeaponDamage()
        {
            return weaponDamage;
        }

        public float getWeaponRange()
        {
            return weaponRange;
        }

    }
}