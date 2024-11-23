using FluentValidation;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO;

namespace HOSPEDAJE.Areas.UsuarioArea.Payloads.FluentDTO
{
    public class FormLoginUsuarioDTO : AbstractValidator<LoginUsuarioDTO>
    {
        public FormLoginUsuarioDTO()
        {
            RuleFor(usuario => usuario.Correo)
                .NotEmpty().WithMessage("El correo es obligatorio.")
                .EmailAddress().WithMessage("El formato del correo es inválido.")
                .Matches(@"^[a-zA-Z0-9._%+-]+@(gmail\.com|hotmail\.com)$").WithMessage("El correo debe ser de Gmail o Hotmail.");
            RuleFor(usuario => usuario.Contraseña)
                .NotEmpty().WithMessage("La contraseña es obligatoria.");
        }
    }
}
