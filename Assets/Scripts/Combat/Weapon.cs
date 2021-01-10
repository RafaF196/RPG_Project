using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RPG.Attributes;

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
        [SerializeField] float weaponPercentageBonus = 0;
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

            var overrideController = animator.runtimeAnimatorController as AnimatorOverrideController;

            if (animatorOverride != null) animator.runtimeAnimatorController = animatorOverride;
            else if (overrideController != null)
            {
                animator.runtimeAnimatorController = overrideController.runtimeAnimatorController;
            }
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

        public void LaunchProjectile(Transform leftHandTransform, Transform rightHandTransform,
            Health target, GameObject instigator, float calculatedDamage)
        {
            Projectile projectileInstance = Instantiate(projectile,
                isRightHanded ? rightHandTransform.position : leftHandTransform.position, Quaternion.identity);
            projectileInstance.SetTarget(target, instigator, calculatedDamage);
        }

        public bool hasProjectile()
        {
            return projectile != null;
        }

        public float getWeaponDamage()
        {
            return weaponDamage;
        }

        public float getPercentageBonus()
        {
            return weaponPercentageBonus;
        }

            public float getWeaponRange()
        {
            return weaponRange;
        }

    }
}