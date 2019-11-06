## Guide

The framework can be used to easily define resources in your REST API. To define a resource simply inherit from the `AbstractResource` class.
For each class that inherits from `AbstractResource` the framework will create a GetAll, Get, Post, Put and Delete endpoint.
The `AbstractResource` class has an ID property that will be inherited by all resources.
