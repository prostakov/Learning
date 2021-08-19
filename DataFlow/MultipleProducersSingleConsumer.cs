using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Common;
using NUnit.Framework;

namespace DataFlow
{
    public class MultipleProducersSingleConsumer : BaseTest
    {
        [Test]
        public async Task Test()
        {
            var producer1 = CreateProducer("producer1");
            var producer2 = CreateProducer("producer2");

            var consumer = CreateConsumer();
            var completion = consumer.Completion.ContinueWith(p =>
            {
                Logger.Information("Completed");
            });

            producer1.LinkTo(consumer, new DataflowLinkOptions {PropagateCompletion = true});
            producer2.LinkTo(consumer, new DataflowLinkOptions {PropagateCompletion = true});

            var producing1 = Task.Run(() => ProduceSomeEvents(producer1));
            var producing2 = Task.Run(() => ProduceSomeEvents(producer2));
            await Task.WhenAll(producing1, producing2);
            
            producer1.Complete();
            producer2.Complete();

            await completion;
        }

        private void ProduceSomeEvents(TransformBlock<int, MyEvent> producerBlock)
        {
            for (int i = 0; i < 10; i++) 
                producerBlock.Post(i);
        }
        
        private ActionBlock<MyEvent> CreateConsumer()
        {
            return new(async myEvent =>
            {
                Logger.Information("Start processing event {EventId} from Producer {ProducerName}", myEvent.Id, myEvent.Source);
                
                await Task.Delay(TheGreatestRandom.Next(1000));
                
                Logger.Information("Finished processing event {EventId} from Producer {ProducerName}", myEvent.Id, myEvent.Source);
                
            }, new ExecutionDataflowBlockOptions {MaxDegreeOfParallelism = 1});
        }

        private TransformBlock<int, MyEvent> CreateProducer(string name)
        {
            return new(input => new MyEvent {Source = name, Id = input});
        }

        private class MyEvent
        {
            public string Source { get; set; }
            public int Id { get; set; }
        }
    }
}