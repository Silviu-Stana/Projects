import { Collection } from '../models/Collection';

export abstract class CollectionView<M, P> {
      // collection: Collection<M, P> = new Collection<M, P>('rootUrl', (json: P) => {
      constructor(public parent: Element, public collection: Collection<M, P>) {}

      render(): void {
            this.parent.innerHTML = '';
            const templateElement = document.createElement('template');

            for (let model of this.collection.models) {
                  const itemParent = document.createElement('div');
                  this.renderItem(model, itemParent);

                  templateElement.content.append(itemParent);
            }

            this.parent.append(templateElement.content);
      }

      abstract renderItem(model: M, itemParent: Element): void;
}
