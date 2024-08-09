using CharUnit = CharCode;
using EnemyUnit = EnemyCode;
public class Status
{
    public CharUnit charUnit { get; } // 바꿀 수 없게 get만
    public EnemyUnit enemyUnit { get; }
    public string name { get; set; }
    public int maxHp { get; set; }
    public int nowHp { get; set; }
    public int atkDmg { get; set; }
    public float atkSpeed { get; set; }
    public float moveSpeed { get; set; }
    public float atkRange { get; set; }
    public float fieldOfVision { get; set; }

    public Status()
    {
    }
    
    public Status(CharUnit charUnit, string name, int maxHp, int atkDmg, float atkSpeed, float moveSpeed, float atkRange, float fieldOfVision)
    {
        this.charUnit = charUnit;
        this.name = name;
        this.maxHp = maxHp;
        nowHp = maxHp;
        this.atkDmg = atkDmg;
        this.atkSpeed = atkSpeed;
        this.moveSpeed = moveSpeed;
        this.atkRange = atkRange;
        this.fieldOfVision = fieldOfVision;
    }

    public Status(EnemyUnit enemyUnit, string name, int maxHp, int atkDmg, float atkSpeed, float moveSpeed, float atkRange, float fieldOfVision)
    {
        this.enemyUnit = enemyUnit;
        this.name = name;
        this.maxHp = maxHp;
        nowHp = maxHp;
        this.atkDmg = atkDmg;
        this.atkSpeed = atkSpeed;
        this.moveSpeed = moveSpeed;
        this.atkRange = atkRange;
        this.fieldOfVision = fieldOfVision;
    }

    public Status SetCharStatus(CharUnit charUnit)
    {
        Status status = null;

        switch (charUnit)
        {
            case CharUnit.slave:
                status = new Status(charUnit, "노비", 50, 10, 1f, 8f, 0, 0);
                break;
            case CharUnit.ordinary:
                status = new Status(charUnit, "평민", 100, 10, 1.5f, 2f, 1.5f, 7f);
                break;
            case CharUnit.noble:
                status = new Status(charUnit, "양반", 100, 10, 1.5f, 2f, 1.5f, 7f);
                break;
            case CharUnit.king:
                status = new Status(charUnit, "왕", 100, 10, 1.5f, 2f, 1.5f, 7f);
                break;
        }
        return status;
    }

    public Status SetEnemyStatus(EnemyUnit enemyUnit)
    {
        Status status = null;

        switch (enemyUnit)
        {
            case EnemyUnit.e1:
                status = new Status(enemyUnit, "적1", 50, 10, 1f, 8f, 0, 0);
                break;
            case EnemyUnit.e2:
                status = new Status(enemyUnit, "적2", 100, 10, 1.5f, 2f, 1.5f, 7f);
                break;
            case EnemyUnit.e3:
                status = new Status(enemyUnit, "적3", 100, 10, 1.5f, 2f, 1.5f, 7f);
                break;
            case EnemyUnit.e4:
                status = new Status(enemyUnit, "적4", 100, 10, 1.5f, 2f, 1.5f, 7f);
                break;
        }
        return status;
    }
}