using UnityEngine;

namespace GalaxyShooter.Core.PowerUps
{
    public class Shield : PowerBuff
    {
        protected override void EnablePowerUp(Player player)
        {
            player.ShieldEnabled(_powerUpDuration);
        }
    }
}
