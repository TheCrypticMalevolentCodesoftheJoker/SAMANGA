using FluentValidation;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO;

namespace HOSPEDAJE.Areas.UsuarioArea.Payloads.FluentDTO
{
    public class FormRegistrarUsuarioDTO : AbstractValidator<RegistrarUsuarioDTO>
    {
        public FormRegistrarUsuarioDTO()
        {
            RuleFor(usuario => usuario.IdRol)
                .NotNull().WithMessage("El rol es obligatorio.");
            RuleFor(usuario => usuario.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .Matches("^[a-zA-Z]+$").WithMessage("El nombre solo debe contener letras.");
            RuleFor(usuario => usuario.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .Matches("^[a-zA-Z]+$").WithMessage("El apellido solo debe contener letras.");
            RuleFor(usuario => usuario.Correo)
                .NotEmpty().WithMessage("El correo es obligatorio.")
                .EmailAddress().WithMessage("El formato del correo es inválido.")
                .Matches(@"^[a-zA-Z0-9._%+-]+@(gmail\.com|hotmail\.com)$").WithMessage("El correo debe ser de Gmail o Hotmail.");
            RuleFor(usuario => usuario.Contraseña)
                .NotEmpty().WithMessage("La contraseña es obligatoria.")
                .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.")
                .Matches(@"[A-Z]").WithMessage("La contraseña debe contener al menos una letra mayúscula.")
                .Matches(@"[a-z]").WithMessage("La contraseña debe contener al menos una letra minúscula.")
                .Matches(@"\d").WithMessage("La contraseña debe contener al menos un número.")
                .Matches(@"[!""#$%&'()*+,\-./:;<=>?@[\\\]_^`{|}~]").WithMessage("La contraseña debe contener al menos un carácter especial.");
            RuleFor(usuario => usuario.Estado)
                .NotEmpty().WithMessage("El estado es obligatorio.");
        }
    }
}
