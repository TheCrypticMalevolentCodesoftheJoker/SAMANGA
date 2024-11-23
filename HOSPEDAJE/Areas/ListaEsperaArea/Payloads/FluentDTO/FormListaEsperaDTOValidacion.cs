using FluentValidation;
using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.EntidadesDTO;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Payloads.FluentDTO
{
    public class FormListaEsperaDTOValidacion : AbstractValidator<ListaEsperaDTO>   
    {
        public FormListaEsperaDTOValidacion()
        {
            RuleFor(ListaEspera => ListaEspera.IdCliente)
            .NotEmpty().WithMessage("ID CLIENTE ES OBLIGATORIO");

            RuleFor(ListaEspera => ListaEspera.Prioridad)
            .NotEmpty().WithMessage("PRIORIDAD ES OBLIGATORIO");

            RuleFor(listaEspera => listaEspera.Estado)
            .Must(estado => estado == "E" || estado == "N")
            .WithMessage("El estado debe ser ESPERA (E) o NOTIFICADO (N).");

            RuleFor(ListaEspera => ListaEspera.Descripcion)
            .NotEmpty().WithMessage("DESCRIPCION ES OBLIGATORIO");

        }
    }
}
