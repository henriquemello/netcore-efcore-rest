using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.Repositories;
using ProductCatalog.ViewModels;
using ProductCatalog.ViewModels.ProductViewModels;

 namespace ProductCatalog.Controllers{
     
     public class ProductController : Controller{
         private readonly ProductRepository _productRepository;
         public ProductController(ProductRepository productRepository){
             _productRepository = productRepository;
         }

         [Route("v1/products")]
         [HttpGet]
         public IEnumerable<ListProductViewModel> Get(){
             return _productRepository.Get();
         }


        [Route("v1/products/{id}")]
        [HttpGet]
        public Product Get(int id){
            return _productRepository.Get(id);
        }

        [Route("v1/products")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorProductViewModel model){
            model.Validate();
            if(model.Invalid){
                return new ResultViewModel{
                    Success = false,
                    Message = "Não foi possivel cadastrar o produto",
                    Data = model.Notifications
                };
            }
            var product = new Product();
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.CreateDate = DateTime.Now;
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _productRepository.Save(product);

            return new ResultViewModel{
                Success = true,
                Message = "Produto Cadastrado com sucesso!",
                Data = product
            };
        }

        [Route("v1/products")]
        [HttpPut]
        public ResultViewModel Put([FromBody]EditorProductViewModel model){
            model.Validate();
            if(model.Invalid){
                return new ResultViewModel{
                    Success = false,
                    Message = "Não foi possivel cadastrar o produto",
                    Data = model.Notifications
                };
            }
            var product = _productRepository.Get(model.Id);
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.CreateDate = DateTime.Now;
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _productRepository.Update(product);

            return new ResultViewModel{
                Success = true,
                Message = "Produto alterado com sucesso!",
                Data = product
            };
        }
     }
 }