using Db.Benchmark.Domain.Enums;
using Db.Benchmark.Domain.Exceptions;

namespace Db.Benchmark.Domain.Models.Orders;

/// <summary>
/// Информация о доставке
/// </summary>
public sealed record OrderDelivery
{
	/// <summary>
	/// ID типа доставки
	/// </summary>
	public required DeliveryTypes Type { get; set; }

	/// <summary>
	/// Статус доставки
	/// </summary>
	public DeliveryStatuses Status { get; private set; } = DeliveryStatuses.Pending;

	/// <summary>
	/// Дата начала доставки
	/// </summary>
	public DateTime? Start { get; private set; }
	/// <summary>
	/// Дата окончания
	/// </summary>
	public DateTime? End { get; private set; }

	/// <summary>
	/// Адрес доставки
	/// </summary>
	public required OrderDeliveryAddress Address { get; set; }

	public void ChangeStatusToInWork()
	{
		if (Status == DeliveryStatuses.Pending)
		{
			Status = DeliveryStatuses.InWork;
		}
		else throw new DomainException("Смена статуса на 'InWork' возможна только при статусе 'Pending'");
	}

	public void ChangeStatusToDelivering()
	{
		if (Status == DeliveryStatuses.InWork)
		{
			Status = DeliveryStatuses.Delivering;
		}
		else throw new DomainException("Смена статуса на 'Delivering' возможна только при статусе 'InWork'");
	}

	public void ChangeStatusToIssued()
	{
		if (Status == DeliveryStatuses.InWork || Status == DeliveryStatuses.Delivering)
		{
			Status = DeliveryStatuses.Issued;
		}
		else throw new DomainException("Смена статуса на 'Issued' возможна только при статусах: 'InWork', 'Delivering'");
	}

	public void ChangeStatusToCanceled()
	{
		if (Status.In(DeliveryStatuses.Pending, DeliveryStatuses.InWork))
		{
			Status = DeliveryStatuses.Canceled;
		}
		else throw new DomainException("Смена статуса на 'Issued' возможна только при статусах: 'Pending', 'InWork'");
	}

	public void UpdateAddress(OrderDeliveryAddress deliveryAddress)
	{
		if (Status.In(DeliveryStatuses.Pending, DeliveryStatuses.InWork))
		{
			Address = deliveryAddress;
		}
		else throw new DomainException("Смена адреса доставки возможна только при статусах: 'Pending', 'InWork'");
	}
}
