using FluentValidation;
using HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO;

namespace HOSPEDAJE.Areas.ClienteArea.Payloads.FluentDTO
{
    public class FormRegistrarClienteDTO : AbstractValidator<RegistrarClienteDTO>
    {
        public FormRegistrarClienteDTO()
        {
            RuleFor(cliente => cliente.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .Matches("^[a-zA-Z]+$").WithMessage("El nombre solo debe contener letras.");

            RuleFor(cliente => cliente.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .Matches("^[a-zA-Z]+$").WithMessage("El apellido solo debe contener letras.");

            RuleFor(cliente => cliente.Correo)
                .NotEmpty().WithMessage("El correo es obligatorio.")
                .EmailAddress().WithMessage("El formato del correo es inválido.")
                .Matches(@"^[a-zA-Z0-9._%+-]+@(gmail\.com|hotmail\.com)$").WithMessage("El correo debe ser de Gmail o Hotmail.");

            RuleFor(cliente => cliente.Contraseña)
                .NotEmpty().WithMessage("La contraseña es obligatoria.")
                .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.")
                .Matches(@"[A-Z]").WithMessage("La contraseña debe contener al menos una letra mayúscula.")
                .Matches(@"[a-z]").WithMessage("La contraseña debe contener al menos una letra minúscula.")
                .Matches(@"\d").WithMessage("La contraseña debe contener al menos un número.")
                .Matches(@"[!""#$%&'()*+,\-./:;<=>?@[\\\]_^`{|}~]").WithMessage("La contraseña debe contener al menos un carácter especial.");

            RuleFor(cliente => cliente.Estado)
                .NotEmpty().WithMessage("El estado es obligatorio.");
        }
    }
}
