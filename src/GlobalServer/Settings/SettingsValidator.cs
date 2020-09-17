using FluentValidation;

namespace GlobalServer.Settings
{
    public class SettingsValidator : AbstractValidator<IGlobalServerSettings>
    {
        public SettingsValidator() =>
            RuleFor(settings => settings.FileName)
                .NotEmpty()
                .WithMessage("No filename was specified, please specify a file i.e. dotnet-server -fileName:C:\\file.txt");
    }
}