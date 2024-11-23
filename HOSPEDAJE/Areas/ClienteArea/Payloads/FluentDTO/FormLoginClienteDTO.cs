using FluentValidation;
using HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO;

namespace HOSPEDAJE.Areas.ClienteArea.Payloads.FluentDTO
{
    public class FormLoginClienteDTO : AbstractValidator<LoginClienteDTO>
    {
        public FormLoginClienteDTO()
        {
            RuleFor(cliente => cliente.Correo)
                .NotEmpty().WithMessage("Por favor, proporciona tu correo.");

            RuleFor(cliente => cliente.Contraseña)
                .NotEmpty().WithMessage("Por favor, proporciona tu contraseña.");
        }
    }
}
