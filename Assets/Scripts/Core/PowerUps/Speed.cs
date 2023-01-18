using UnityEngine;

namespace GalaxyShooter.Core.PowerUps
{
    public class Speed : PowerBuff
    {
        [SerializeField] private float _speedBoost;
        protected override void EnablePowerUp(Player player)
        {
            player.SpeedBoostEnabled(_speedBoost, _powerUpDuration);
        }
    }
}
