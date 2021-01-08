using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;
using System;

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

        const string weaponName = "Weapon";

        public void Spawn(Transform leftHandTransform, Transform rightHandTransform, Animator animator)
        {
            DestroyOldWeapon(leftHandTransform, rightHandTransform);

            if (equipedPrefab != null)
            {
                GameObject weapon = Instantiate(equipedPrefab, isRightHanded ? rightHandTransform : leftHandTransform);
                weapon.name = weaponName;
            }
            if (animatorOverride != null) animator.runtimeAnimatorController = animatorOverride;
        }

        private void DestroyOldWeapon(Transform leftHandTransform, Transform rightHandTransform)
        {
            Transform oldWeapon = rightHandTransform.Find(weaponName);
            if (oldWeapon == null)
            {
                oldWeapon = leftHandTransform.Find(weaponName);
            }
            if (oldWeapon == null) return;
            oldWeapon.name = "DESTROYING";
            Destroy(oldWeapon.gameObject);
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