﻿using Domain;

namespace Application.UseCases;

public interface IPagamentoUseCase
{
    Task EfetuarMercadoPagoQRCodeAsync(Guid pedidoId);
}
