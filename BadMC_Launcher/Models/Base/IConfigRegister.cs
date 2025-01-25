namespace BadMC_Launcher.Models.Base;

public interface IConfigRegister<TRegisterType> {
    
    private TRegisterType[] Container { get; set; }

    public void Register(TRegisterType registerType);
}
