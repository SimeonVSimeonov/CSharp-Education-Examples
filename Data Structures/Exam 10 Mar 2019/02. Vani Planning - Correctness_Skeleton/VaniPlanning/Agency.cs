using System;
using System.Collections.Generic;
using System.Linq;

public class Agency : IAgency
{
    Dictionary<string, Invoice> bySerialNum = new Dictionary<string, Invoice>();

    public bool Contains(string number)
    {
        return this.bySerialNum.ContainsKey(number);
    }

    public int Count()
    {
        return this.bySerialNum.Count;
    }

    public void Create(Invoice invoice)
    {
        if (!this.bySerialNum.ContainsKey(invoice.SerialNumber))
        {
            bySerialNum.Add(invoice.SerialNumber, invoice);
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public void ExtendDeadline(DateTime dueDate, int days)
    {
        foreach (var item in this.bySerialNum)
        {
            if (item.Value.DueDate == dueDate)
            {
                item.Value.DueDate.AddDays(days);
            }
            else
            {
                throw new ArgumentException();
            }
        }

    }

    public IEnumerable<Invoice> GetAllByCompany(string company)
    {
        return this.bySerialNum.Values.Where(c => c.CompanyName == company)
            .OrderByDescending(n => n.SerialNumber);
    }

    public IEnumerable<Invoice> GetAllFromDepartment(Department department)
    {
        return this.bySerialNum.Values.Where(d => d.Department == department)
            .OrderByDescending(t => t.Subtotal)
            .ThenBy(d => d.IssueDate);
    }

    public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
    {
        return this.bySerialNum.Values.Where(d => d.IssueDate >= start && d.IssueDate <= end)
            .OrderBy(c => c.IssueDate)
            .ThenBy(d => d.DueDate);
            
    }

    public void PayInvoice(DateTime due)
    {
        var count = 0;
        foreach (var item in this.bySerialNum)
        {

            if (item.Value.DueDate == due)
            {
                item.Value.Subtotal = 0.0;
                count++;
            }
        }

        if (count == 0)
        {
            throw new ArgumentException();
        }
       
    }

    public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
    {

        return this.bySerialNum.Values.Where(c => c.SerialNumber.Contains(serialNumber))
            .OrderByDescending(n => n.SerialNumber);
 
     
    }

    public void ThrowInvoice(string number)
    {
        if (!this.bySerialNum.ContainsKey(number))
        {
            throw new ArgumentException();
        }
        this.bySerialNum.Remove(number);
    }

    public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
    {
        var dict = new Dictionary<string, Invoice>();

        foreach (var item in this.bySerialNum)
        {
            if (item.Value.DueDate > start && item.Value.DueDate < end)
            {
                this.bySerialNum.Remove(item.Key);
            }
            else
            {
                dict.Add(item.Key, item.Value);
            }
        }

        return dict.Values;
        //throw new NotImplementedException();
    }

    public void ThrowPayed()
    {
        //this.bySerialNum.Values.Where(s => s.Subtotal == 0)
       
    }
}
