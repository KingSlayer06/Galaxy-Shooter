
namespace GalaxyShooter.Core.PowerUps
{
    public class TripleShot : PowerBuff
    {
        protected override void EnablePowerUp(Player player)
        {
            player.TripleShotEnabled(_powerUpDuration);
        }
    }
}