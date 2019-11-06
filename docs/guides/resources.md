# Resources

Resources are a core part of every ServiceBlock. They are represented by a class inheriting from the `AbstractResource` class. Here's an example of an Invoice resource with Memory [storage](storage.md):

```csharp
[Storage(typeof(MemoryStorage<>))]
public class Invoice : AbstractResource
{
    public string InvoiceNumber { get; set; }
}
```

Whenever a resource is defined the ServiceBlock framework will create 5 endpoints.

* GET /Invoice
* GET /Invoice/{Id}
* POST /Invoice
* PUT /Invoice/{Id}
* DELETE /Invoice/{Id}

Where {Id} is a guid.

The GET endpoints will retrieve the resource from storage. The POST endpoint will create a resource. The PUT will replace it. And the DELETE will remove the resource.

## The ReadOnly attribute

Sometimes you might want to have a property which can be read, but not modified through the API, for example the date a resource was created. To achieve this, you can use the `ReadOnlyAttribute` from `System.ComponentModel`. When you use the `ReadOnlyAttribute` you must also define a default value for when a resource is created. Below is an example of adding created-date to our Invoice resource.

**Note:** You may also apply the ReadOnly attribute to the resource itself, which will disable all write actions.

```csharp
[Storage(typeof(MemoryStorage<>))]
public class Invoice : AbstractResource
{
    public string InvoiceNumber { get; set; }

    [ReadOnly(true)]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow();
}
```

## The Queryable attribute

The `QueryableAttribute` enables you to make a resource searchable by a property.

When the attribute is applied to a resource property, it will enable the end user to use query string parameters on your resource to search them.

**Example:**

```csharp
[Storage(typeof(MemoryStorage<>))]
public class Invoice : AbstractResource
{
    [Queryable]
    public string InvoiceNumber { get; set; }

    [ReadOnly(true)]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow();
}
```

Will enable you to use `GET /Invoice?InvoiceNumber=asd` to search for all invoices with `asd` as the invoice number.

